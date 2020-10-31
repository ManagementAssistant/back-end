using System;
using System.Collections.Generic;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Model.Enums
{
    public enum HierarchyType
    {
        Staff = 100, //En alt kademe 
        DM = 200, //Departman Yöneticisi
        Admin = 300, //Departmana ait bilgilerin tümünü görme yetkisine sahip verilen departman iznine göre
        GM = 400, //Firmanın en tepesindeki 
        Developer = 500 
    }
}
