using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace test.Datas
{
    public class AddressesDataStore
    {
        public static AddressesDataStore current { get; } = new AddressesDataStore();
        public List<AddressDTO> LAddesses{get;set;}
        public AddressesDataStore()
        {
            LAddesses = new List<AddressDTO>()
            {
                new AddressDTO()
                {
                    iID=1,
                    sName="Kim Jong Un",
                    sPhoneNumber="+850-166-666-6666",
                    sAddress="Triều Tiên",
                    sMoreInfo="Mập, tóc 2 mái, thích chơi tên lửa"
                },
                new AddressDTO()
                {
                    iID=2,
                    sName="Đỗ Namm Trung",
                    sPhoneNumber="+1-888-999-9999",
                    sAddress="Mẽo",
                    sMoreInfo="Cao, có sách best seller, vợ trẻ đẹp"
                },
                new AddressDTO()
                {
                    iID=3,
                    sName="Hồ Cẩm Đào",
                    sPhoneNumber="+86-888-111-1111",
                    sAddress="tàu",
                    sMoreInfo="nhìn mặt thấy ghét"
                },
                new AddressDTO()
                {
                    iID=4,
                    sName="Putin",
                    sPhoneNumber="+7-111-222-3333",
                    sAddress="Nga",
                    sMoreInfo="Gấu Nga vĩ đại :))"
                },
                new AddressDTO()
                {
                    iID=5,
                    sName="Lộc",
                    sPhoneNumber="+84-166-33-89098",
                    sAddress="Việt Nam",
                    sMoreInfo="đẹp trai thanh lịch vô địch khắp vũ trụ"
                },
                new AddressDTO()
                {
                    iID=6,
                    sName="lại là Lộc",
                    sPhoneNumber="+84-123-418-8566",
                    sAddress="Việt Nam",
                    sMoreInfo=null
                }
            };

                
        }
    }
}
