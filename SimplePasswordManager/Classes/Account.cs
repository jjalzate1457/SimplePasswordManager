using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace SimplePasswordManager
{
    public class Account : IComparable<Account>
    {
        public Guid Id { get; set; }
        public AccountType AccountType { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Account()
        {
            Id = Guid.NewGuid();
        }

        public void Update(Account acct)
        {
            Id = acct.Id;
            Name = acct.Name;
            Username = acct.Username;
            Password = acct.Password;
        }

        public int CompareTo(Account other)
        {
            if (Id != other.Id ||
            Name != other.Name ||
            Username != other.Username ||
            Password != other.Password)
                return 0;

            return 1;
        }
    }

    public enum AccountType
    {
        UsernamePassword,
        PIN
    }

    public class AccountList : BindingList<Account>
    {
        public Account Current { get; set; }

        public void Load(string pass)
        {
            if (File.Exists(Common.FileExportFilename))
            {
                var lines = File.ReadAllLines(Common.FileExportFilename);

                foreach (var line in lines)
                {
                    var data = line.Split(',');

                    Add(new Account
                    {
                        Id = Guid.Parse(Cipher.Decrypt(data[0], pass)),
                        AccountType = Cipher.Decrypt(data[1], pass) == "1" ? AccountType.PIN : AccountType.UsernamePassword,
                        Name = Cipher.Decrypt(data[2], pass),
                        Username = Cipher.Decrypt(data[3], pass),
                        Password = Cipher.Decrypt(data[4], pass)
                    });
                }
            }
        }
        public void Update(Account acct)
        {
            var items = (Items as List<Account>).FindAll(item => item.Id == acct.Id);
            if (items.Count > 0)
            {
                items[0].Update(acct);
            }
        }

        public bool Save(string pass)
        {
            try
            {
                List<string> dataLines = new List<string>();

                foreach (var account in this)
                {
                    dataLines.Add(
                        Cipher.Encrypt(account.Id.ToString(), pass) + "," +
                        Cipher.Encrypt(account.AccountType == AccountType.PIN ? "1" : "0", pass) + "," +
                        Cipher.Encrypt(account.Name, pass) + "," +
                        Cipher.Encrypt(account.Username, pass) + "," +
                        Cipher.Encrypt(account.Password, pass));
                }

                File.WriteAllLines(Common.FileExportFilename, dataLines);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SaveExport(string pass, string filePath = "", bool encrypted = true)
        {
            try
            {
                if (filePath == "")
                    filePath = Common.FileExportFilename;

                List<string> dataLines = new List<string>();

                foreach (var account in this)
                {
                    dataLines.Add(
                        (encrypted ? Cipher.Encrypt(account.Id.ToString(), pass) : account.Id.ToString()) + "," +
                        (encrypted ? Cipher.Encrypt(account.AccountType == AccountType.PIN ? "1" : "0", pass) : (account.AccountType == AccountType.PIN ? "1" : "0")) + "," +
                        (encrypted ? Cipher.Encrypt(account.Name, pass) : account.Name) + "," +
                        (encrypted ? Cipher.Encrypt(account.Username, pass) : account.Username) + "," +
                        (encrypted ? Cipher.Encrypt(account.Password, pass) : account.Password));
                }

                File.WriteAllLines(filePath, dataLines);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Reset()
        {
            Clear();
            File.Delete(Common.FileExportFilename);
        }
    }
}
