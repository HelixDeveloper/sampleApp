using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sampleApp.myDB;
namespace sampleApp.Areas.Admin.Data
{
    public class AdminModel
    {
        public int id { get; set; }
        public string uname { get; set; }
        public string upass { get; set; }
        public string adminName { get; set; }
        public DateTime logindate { get; set; }

        public AdminModel checkLogin() {
            try
            {
                using (myappdbEntities db = new myappdbEntities()) {
                    adminTbl admin = db.adminTbls.SingleOrDefault(asd=>asd.uname == uname && asd.upass == upass);
                    if (admin != null)
                    {
                        AdminModel am = new AdminModel();
                        am.id = admin.id;
                        am.uname = admin.uname;
                        am.upass = admin.upass;
                        am.adminName = admin.adminName;
                        am.logindate = DateTime.Now;
                        return am;
                        //return true;
                    }
                    else {
                        return new AdminModel();
                        //return false;
                    }
                }
            }
            catch (Exception e)
            {
                //return false;
                return new AdminModel();
            }
        }
    }
}