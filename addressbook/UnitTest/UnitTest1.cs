using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetFullAddressBook()
        {
            //arange
            string expected = "[{\"iID\":1,\"sName\":\"Un in un in\",\"sPhoneNumber\":\"+850-166-666-6666\",\"sAddress\":\"Triều Tiên\",\"sMoreInfo\":\"Mập, tóc 2 mái, thích chơi tên lửa\"},{\"iID\":2,\"sName\":\"Đỗ Namm Trung\",\"sPhoneNumber\":\"+1-888-999-9999\",\"sAddress\":\"Mẽo\",\"sMoreInfo\":\"Cao, có sách best seller, vợ trẻ đẹp\"},{\"iID\":3,\"sName\":\"Một Người Bạn\",\"sPhoneNumber\":\"+86-888-111-1111\",\"sAddress\":\"tàu\",\"sMoreInfo\":\"nhìn mặt thấy ghét\"},{\"iID\":4,\"sName\":\"Gấu AK\",\"sPhoneNumber\":\"+7-111-222-3333\",\"sAddress\":\"Nga\",\"sMoreInfo\":\"Gấu Nga vĩ đại :))\"},{\"iID\":5,\"sName\":\"Lộc\",\"sPhoneNumber\":\"+84-166-33-89098\",\"sAddress\":\"Việt Nam\",\"sMoreInfo\":\"đẹp trai thanh lịch vô địch khắp vũ trụ\"},{\"iID\":6,\"sName\":\"lại là Lộc\",\"sPhoneNumber\":\"+84-123-418-8566\",\"sAddress\":\"Việt Nam\",\"sMoreInfo\":null}]";
            string actual = "";
            //act
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:63972/api/addressbook");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            actual = new StreamReader(response.GetResponseStream()).ReadToEnd();
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestGetTruethAddressId()
        {
            //arange
            string expected = "{\"iID\":3,\"sName\":\"Một Người Bạn\",\"sPhoneNumber\":\"+86-888-111-1111\",\"sAddress\":\"tàu\",\"sMoreInfo\":\"nhìn mặt thấy ghét\"}";
            string actual = "";
            //act
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:63972/api/addressbook/3");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            actual = new StreamReader(response.GetResponseStream()).ReadToEnd();
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestWrongAddressId()
        {
            //arange
            string ExpectedString = "Not Found";
            int ExpectedStatuscode = 404;
            string ActualString = "";
            int ActualStatusCode = 404;
            //act

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:63972/api/addressbook/9");
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                ActualStatusCode = (int)response.StatusCode;
            }
            catch (Exception e)
            {
            }
            
            
            Assert.AreEqual(ExpectedStatuscode, ActualStatusCode);
            
        }
    }
}
