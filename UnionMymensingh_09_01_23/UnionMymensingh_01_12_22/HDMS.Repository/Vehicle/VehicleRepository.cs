using HDMS.Model.Enums;
using HDMS.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HDMS.Repository.Vehicle
{
    public class VehicleRepository
    {
        public bool SaveCar(CarInfo carInfo)
        {
            using (DBEntities entities=new DBEntities())
            {
                try
                {
                    entities.CarInfoes.Add(carInfo);
                    entities.SaveChanges();
                    return true;

                }catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public CarInfo GetCar(int carId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.CarInfoes.Where(x=>x.CarId==carId).FirstOrDefault();
                }catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public bool UpRouteInfo(RoutingOrTripInfo tripInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(tripInfo).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;

                }catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public RoutingOrTripInfo GetRoute(int routeId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.RoutingOrTripInfoes.Where(x=>x.RouteId==routeId).FirstOrDefault();
                }catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public bool SaveRent(RoutingOrTripInfo tripInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.RoutingOrTripInfoes.Add(tripInfo);
                    entities.SaveChanges();
                    return true;
                }catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public IList<DriverInfo> GetAllAvailableDriver()
        {

            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.DriverInfoes.Where(x=>x.DStatus.Equals(DriverStatus.Available.ToString())).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public bool SaveAllotmentInfo(CarAllotmentInfo carAllotmentInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                using (var transaction = entities.Database.BeginTransaction())
                {
                    try
                    {
                        entities.CarAllotmentInfoes.Add(carAllotmentInfo);
                        entities.SaveChanges();

                        Thread.Sleep(200);

                        List<CarAndDriverLedger> ledgersList =entities.CarAndDriverLedgers.Where(x=>x.DriverId==carAllotmentInfo.DriverId && x.CarId==carAllotmentInfo.CarId).ToList();
                        double balance = ledgersList.Sum(x=>x.debit);
                        double _debit = carAllotmentInfo.Rent;
                        CarAndDriverLedger ledger = new CarAndDriverLedger();
                        ledger.TDate = carAllotmentInfo.ADate;
                        ledger.CarId = carAllotmentInfo.CarId;
                        ledger.DriverId = carAllotmentInfo.DriverId;
                        ledger.debit = _debit;
                        ledger.credit = 0;
                        ledger.balance = balance +_debit;
                       

                        entities.CarAndDriverLedgers.Add(ledger);
                        entities.SaveChanges();

                        transaction.Commit();
                        return true;

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
                
            }
        }

        public IList<CarInfo> GetAllAvailableCar()
        {
            
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.CarInfoes.Where(x=>x.CStatus.Equals(CarStatus.Available.ToString())).ToList();

                }catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public IList<RoutingOrTripInfo> GetAllRoute()
        {
            
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.RoutingOrTripInfoes.ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public IList<RoutingOrTripInfo> GetRouteInfo()
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.RoutingOrTripInfoes.ToList();
                }catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public IList<DriverInfo> GetDriverList()
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.DriverInfoes.ToList();
                }catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public bool UpDriverInfo(DriverInfo driver)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(driver).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public DriverInfo GetDriver(int driverId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.DriverInfoes.Where(x=>x.DriverId==driverId).FirstOrDefault();
                }catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public bool SaveDriverInfo(DriverInfo driver)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.DriverInfoes.Add(driver);
                    entities.SaveChanges();
                    return true;

                }catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public bool UpCarInfo(CarInfo carInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(carInfo).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public IList<CarInfo> GetCarList()
        {
            using (DBEntities entities=new DBEntities())
            {
                try
                {
                    return entities.CarInfoes.ToList();
                }catch(Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
