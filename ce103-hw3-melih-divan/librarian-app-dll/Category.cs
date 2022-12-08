using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Category
    {

        public const int CATEGORY_NAME_LENGTH = 40;

        public const int CATEGORY_MAX_LENGTH = CATEGORY_NAME_LENGTH;

        private string _name;

        public string Name { get { return _name; } set { _name = value; } }

        public Category()
        {
        }


        public static byte[] CategoryToByteArrayBlock(Category category)
        {
            int index = 0;

            byte[] dataBuffer = new byte[CATEGORY_MAX_LENGTH];


            #region copy category name
            byte[] nameBytes = ConversionUtility.StringToByteArray(category.Name);
            Array.Copy(nameBytes, 0, dataBuffer, index, nameBytes.Length);
            index += Category.CATEGORY_NAME_LENGTH;
            #endregion

            if (index != dataBuffer.Length)
            {
                throw new ArgumentException("Index and DataBuffer Size Not Matched");
            }

            return dataBuffer;
        }

        public static Category ByteArrayBlockToCategory(byte[] byteArray)
        {

            Category category = new Category();

            if (byteArray.Length != CATEGORY_MAX_LENGTH)
            {
                throw new ArgumentException("Byte Array Size Not Match with Constant Data Block Size");
            }

            int index = 0;

            #region copy category name
            byte[] nameBytes = new byte[Category.CATEGORY_NAME_LENGTH];
            Array.Copy(byteArray, index, nameBytes, 0, nameBytes.Length);
            category.Name = ConversionUtility.ByteArrayToString(nameBytes);

            index += Category.CATEGORY_MAX_LENGTH;
            #endregion

            if (index != byteArray.Length)
            {
                throw new ArgumentException("Index and DataBuffer Size Not Matched");
            }

            if (String.IsNullOrEmpty(category.Name))
            {
                return null;
            }
            else
            {
                return category;
            }
        }
    }
}
