using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace CH.Common.Security
{
    public class CryptoEngine
    {
        static RC2CryptoServiceProvider rc2CSP;
        static DESCryptoServiceProvider desProvider;
        static CryptoEngine()
        {
            rc2CSP = new RC2CryptoServiceProvider();
            desProvider = new DESCryptoServiceProvider();
        }

        #region RijndaelManaged

        public static string RijndaelManagedEncryption(string plainText, string password)
        {
            byte[] text = Encoding.ASCII.GetBytes(plainText);

            RijndaelManaged RijndaelCipher = new RijndaelManaged();

            byte[] salt = Encoding.ASCII.GetBytes(password.Length.ToString());

            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(password, salt);

            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream();

            CryptoStream encStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
            encStream.Write(text, 0, text.Length);

            encStream.FlushFinalBlock();

            byte[] CipherBytes = memoryStream.ToArray();

            memoryStream.Close();
            encStream.Close();

            return Convert.ToBase64String(CipherBytes);
        }

        public static string RijndaelManagedDecryption(string plainText, string password)
        {
            byte[] text = Convert.FromBase64String(plainText);

            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            byte[] salt = Encoding.ASCII.GetBytes(password.Length.ToString());

            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(password, salt);

            ICryptoTransform decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream(text);

            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            text = new byte[text.Length];
            int DecryptedCount = cryptoStream.Read(text, 0, text.Length);

            memoryStream.Close();
            cryptoStream.Close();


            return Encoding.ASCII.GetString(text);
        }


        #endregion

        #region RC2Provider

        public static string RC2ProviderEncryption(string plainText, string password)
        {
            byte[] text = Encoding.ASCII.GetBytes(plainText);

            PasswordDeriveBytes cdk = new PasswordDeriveBytes(password, null);

            // generate an RC2 key
            byte[] iv = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            byte[] key = cdk.CryptDeriveKey("RC2", "SHA1", 128, iv);

            // setup an RC2 object to encrypt with the derived key
            rc2CSP.Key = key;
            rc2CSP.IV = new byte[] { 21, 22, 23, 24, 25, 26, 27, 28 };

            // Get an encryptor.
            ICryptoTransform encryptor = rc2CSP.CreateEncryptor(rc2CSP.Key, rc2CSP.IV);
            byte[] encrypted = GenericEncryptor(text, encryptor);

            // Convert the byte array back into a string.
            return Convert.ToBase64String(encrypted);
        }

        public static byte[] GenericEncryptor(byte[] text, ICryptoTransform encryptor)
        {

            // Encrypt the data as an array of encrypted bytes in memory.
            MemoryStream msEncrypt = new MemoryStream();
            CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

            // Write all data to the crypto stream and flush it.
            csEncrypt.Write(text, 0, text.Length);
            csEncrypt.FlushFinalBlock();

            // Get the encrypted array of bytes.
            byte[] encrypted = msEncrypt.ToArray();
            return encrypted;
        }

        public static string RC2ProviderDecryption(string plainText, string password)
        {
            byte[] text = Convert.FromBase64String(plainText);

            PasswordDeriveBytes cdk = new PasswordDeriveBytes(password, null);

            // generate an RC2 key
            byte[] iv = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            byte[] key = cdk.CryptDeriveKey("RC2", "SHA1", 128, iv);

            // setup an RC2 object to encrypt with the derived key
            rc2CSP.Key = key;
            rc2CSP.IV = new byte[] { 21, 22, 23, 24, 25, 26, 27, 28 };

            //Get a decryptor that uses the same key and IV as the encryptor.
            ICryptoTransform decryptor = rc2CSP.CreateDecryptor(rc2CSP.Key, rc2CSP.IV);

            string decStr = GenericDecryptor(text, decryptor);
            
            return decStr;
        }

        #endregion

        #region DES Encryption

        public static string DESProviderEncryption(string plainText, string password)
        {
            byte[] text = Encoding.ASCII.GetBytes(plainText);

            PasswordDeriveBytes cdk = new PasswordDeriveBytes(password, null);

            // generate an RC2 key
            byte[] iv = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            byte[] key = cdk.CryptDeriveKey("DES", "SHA1", desProvider.KeySize, iv);

            // setup an RC2 object to encrypt with the derived key
            desProvider.Key = key;
            desProvider.IV = new byte[] { 21, 22, 23, 24, 25, 26, 27, 28 };

            ICryptoTransform encryptor = desProvider.CreateEncryptor(desProvider.Key, desProvider.IV);
            byte[] encrypted = GenericEncryptor(text, encryptor);


            string rs = Convert.ToBase64String(encrypted);

            string ers = rs.StringToHexString(System.Text.Encoding.UTF8);

            return ers;
           // return Convert.ToBase64String(encrypted);
        }

        public static string DESProviderDecryption(string plainText, string password)
        {

            string rs= plainText.HexStringToString(System.Text.Encoding.UTF8);

            byte[] text = Convert.FromBase64String(rs);

            PasswordDeriveBytes cdk = new PasswordDeriveBytes(password, null);

            // generate an RC2 key
            byte[] iv = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            byte[] key = cdk.CryptDeriveKey("DES", "SHA1", desProvider.KeySize, iv);

            // setup an RC2 object to encrypt with the derived key
            desProvider.Key = key;
            desProvider.IV = new byte[] { 21, 22, 23, 24, 25, 26, 27, 28 };

            // Create a memory stream to the passed buffer.
            MemoryStream ms = new MemoryStream(text);
            ICryptoTransform decryptor = desProvider.CreateDecryptor(desProvider.Key, desProvider.IV);
            
            string decStr = GenericDecryptor(text, decryptor);

            return decStr;
        }


        #endregion

        public static string GenericDecryptor(byte[] cypher, ICryptoTransform decryptor)
        {

            // Now decrypt the previously encrypted message using the decryptor
            // obtained in the above step.
            MemoryStream msDecrypt = new MemoryStream(cypher);
            CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);

            StreamReader sr = new StreamReader(csDecrypt, Encoding.ASCII);
            string decStr = sr.ReadToEnd();

            msDecrypt.Close();
            csDecrypt.Close();
            sr.Close();
            return decStr;
        }

    }
}
