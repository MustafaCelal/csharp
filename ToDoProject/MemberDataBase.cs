using System.Collections.Generic;
using System.Linq;

namespace ToDoProject
{
    public static class MemberDataBase
    {
        public static List<Member> Members=null;

        static MemberDataBase()
        {
            Members = new List<Member>
            {
                new Member{Id=1,FullName="Ali Veli" },
                new Member{Id=2,FullName="Ayşe Fatma"},
                new Member{Id=3,FullName="Ahmet Mehmet"}
            };
        }

        public static Member FindMember(int personId)
        {
            return MemberDataBase.Members.FirstOrDefault(x => x.Id == personId);
        }
    }
}
