using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void TAdd(SocialMedia t)
        {
            _socialMediaDal.Insert(t);
        }

        public SocialMedia TGetByID(int id)
        {
            return _socialMediaDal.GetByID(id);
        }

        public List<SocialMedia> TGetList()
        {
            return _socialMediaDal.GetList();
        }

        public void TRemove(SocialMedia t)
        {
            _socialMediaDal.Delete(t);
        }

        public void TUpdate(SocialMedia t)
        {
            _socialMediaDal.Update(t);
        }
    }
}
