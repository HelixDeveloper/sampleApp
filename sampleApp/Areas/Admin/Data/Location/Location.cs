using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sampleApp.Areas.Admin.Data.Location
{
    public class Location
    {
    }

    public class Country {
        public int countryID { get; set; }
        public string countryName { get; set; }
        public bool isActive { get; set; }


        public bool addNewCountry() {
            try
            {
                using (myDB.myappdbEntities db = new myDB.myappdbEntities())
                {
                    db.countryTbls.Add(new myDB.countryTbl() { 
                        countryName=countryName,
                        isActive = isActive
                    });
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception er)
            {
                return true;
            }
        }

        /// <summary>
        /// DevelopedBY: Brijesh
        /// Purpose: to get list of countries from db
        /// Create Date: 5/10/2023
        /// Update Date: N/A
        /// Old data:  N/A
        /// </summary>
        /// <returns></returns>
        public List<Country> GetCountries() {
            try
            {
                using (myDB.myappdbEntities db = new myDB.myappdbEntities()) {
                    List<myDB.countryTbl> lst = db.countryTbls.ToList();

                    List<Country> lstCountries = new List<Country>();
                    foreach (var item in lst)
                    {
                        Country c = new Country();
                        c.countryID = item.countryID;
                        c.countryName = item.countryName;
                        c.isActive = item.isActive.Value;
                        lstCountries.Add(c);
                    }
                    return lstCountries;
                }
            }
            catch (Exception e)
            {
                return new List<Country>();
            }
        }

        /// <summary>
        /// to update country in db
        /// brijesh
        /// 5=10=2023
        /// </summary>
        /// <returns></returns>
        public bool updateCountry()
        {
            try
            {
                using (myDB.myappdbEntities db = new myDB.myappdbEntities()) {
                    myDB.countryTbl obj = db.countryTbls.SingleOrDefault(asd=>asd.countryID == countryID);
                    if (obj != null)
                    {
                        obj.countryName = countryName;
                        obj.isActive = isActive;
                        db.SaveChanges();
                        return true;
                    }
                    else {
                        return false;
                    }
                } 
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// to remove country from db
        /// brijesh
        /// 5/10/2023
        /// </summary>
        /// <returns></returns>
        public bool removeCountry()
        {
            try
            {
                using (myDB.myappdbEntities db = new myDB.myappdbEntities())
                {
                    myDB.countryTbl obj = db.countryTbls.SingleOrDefault(asd => asd.countryID == countryID);
                    if (obj != null)
                    {
                        db.countryTbls.Remove(obj);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }

    public class State
    {
        public int stateID { get; set; }
        public int fkcountryID { get; set; }
        public string stateName { get; set; }
        public bool isActive { get; set; }
        public string countryName { get; set; }

        public List<State> GetStates() {
            try
            {
                using (myDB.myappdbEntities db = new myDB.myappdbEntities())
                {
                    var lst = (from s in db.stateTbls
                                 join c in db.countryTbls 
                                 on s.fkcountryID equals c.countryID
                                 select new
                                 {
                                     s.stateID,
                                     s.stateName,
                                     s.fkcountryID,
                                     s.isActive,
                                     c.countryName
                                 }).ToList();

                    //List < myDB.stateTbl > lst = db.stateTbls.ToList();
                    List<State> lstStates = new List<State>();

                    foreach (var item in lst)
                    {
                        State s = new State();
                        s.stateID = item.stateID;
                        s.stateName = item.stateName;
                        s.fkcountryID = item.fkcountryID.Value;
                        s.isActive = item.isActive.Value;
                        s.countryName = item.countryName;
                        lstStates.Add(s);
                    }
                    return lstStates;
                }
            }
            catch (Exception err)
            {
                return new List<State>();
            }
        }

        public bool updateState() {
            using (myDB.myappdbEntities db = new myDB.myappdbEntities()) {
                myDB.stateTbl st = db.stateTbls.SingleOrDefault(asd=>asd.stateID == stateID);
                if (st != null) {
                    st.stateName = stateName;
                    st.isActive = isActive;
                    st.fkcountryID = fkcountryID;
                    db.SaveChanges();
                    return true;
                }
                else { return false; }
            }
        }

        public bool removeState()
        {
            using (myDB.myappdbEntities db = new myDB.myappdbEntities())
            {
                myDB.stateTbl st = db.stateTbls.SingleOrDefault(asd => asd.stateID == stateID);
                if (st != null)
                {
                    db.stateTbls.Remove(st);
                    db.SaveChanges();
                    return true;
                }
                else { return false; }
            }
        }

        public bool addNewState() {
            try
            {
                using (myDB.myappdbEntities db = new myDB.myappdbEntities()) {
                    myDB.stateTbl st = new myDB.stateTbl();
                    st.stateName = stateName;
                    st.fkcountryID = fkcountryID;
                    st.isActive = isActive;
                    db.stateTbls.Add(st);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception err)
            {
                return false;
            }
        }

    }
}