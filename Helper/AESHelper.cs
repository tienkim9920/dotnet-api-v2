﻿using System.Security.Cryptography;
using System.Text;
namespace Web_Api_Computer_Shop.Helper
{
    public class AESHelper
    {
        private readonly string _key = "mysmallkey123456";
        private readonly string _iv = "HR$2pIjHR$2pIj12";
        //Code to encrypt Data :   
        public string encryptdata(string encryptdata)
        {
            byte[] bytearraytoencrypt = Encoding.ASCII.GetBytes(encryptdata);
            AesCryptoServiceProvider dataencrypt = new AesCryptoServiceProvider();
            //Block size : Gets or sets the block size, in bits, of the cryptographic operation.  
            dataencrypt.BlockSize = 128;
            //KeySize: Gets or sets the size, in bits, of the secret _key  
            dataencrypt.KeySize = 128;
            //Key: Gets or sets the symmetric _key that is used for encryption and decryption.  
            dataencrypt.Key = System.Text.Encoding.UTF8.GetBytes(_key);
            //IV : Gets or sets the initialization vector (IV) for the symmetric algorithm  
            dataencrypt.IV = System.Text.Encoding.UTF8.GetBytes(_iv);
            //Padding: Gets or sets the padding mode used in the symmetric algorithm  
            dataencrypt.Padding = PaddingMode.PKCS7;
            //Mode: Gets or sets the mode for operation of the symmetric algorithm  
            dataencrypt.Mode = CipherMode.CBC;
            //Creates a symmetric AES encryptor object using the current _key and initialization vector (IV).  
            ICryptoTransform crypto1 = dataencrypt.CreateEncryptor(dataencrypt.Key, dataencrypt.IV);
            //TransformFinalBlock is a special function for transforming the last block or a partial block in the stream.   
            //It returns a new array that contains the remaining transformed bytes. A new array is returned, because the amount of   
            //information returned at the end might be larger than a single block when padding is added.  
            byte[] encrypteddata = crypto1.TransformFinalBlock(bytearraytoencrypt, 0, bytearraytoencrypt.Length);
            crypto1.Dispose();
            //return the encrypted data  
            return Encoding.ASCII.GetString(encrypteddata);
        }

        //code to decrypt data
        private string decryptdata(string decryptdata)
        {
            byte[] bytearraytodecrypt = Encoding.ASCII.GetBytes(decryptdata);
            AesCryptoServiceProvider keydecrypt = new AesCryptoServiceProvider();
            keydecrypt.BlockSize = 128;
            keydecrypt.KeySize = 128;
            keydecrypt.Key = System.Text.Encoding.UTF8.GetBytes(_key);
            keydecrypt.IV = System.Text.Encoding.UTF8.GetBytes(_iv);
            keydecrypt.Padding = PaddingMode.PKCS7;
            keydecrypt.Mode = CipherMode.CBC;
            ICryptoTransform crypto1 = keydecrypt.CreateDecryptor(keydecrypt.Key, keydecrypt.IV);

            byte[] returnbytearray = crypto1.TransformFinalBlock(bytearraytodecrypt, 0, bytearraytodecrypt.Length);
            crypto1.Dispose();
            return Encoding.ASCII.GetString(returnbytearray);
        }
    }
}
