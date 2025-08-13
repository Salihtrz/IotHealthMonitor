using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BranchManager : IBranchService
    {
        private readonly IBranchDal _branchDal;

        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }

        public void TAdd(Branch t)
        {
            _branchDal.Add(t);
        }

        public void TDelete(Branch t)
        {
            _branchDal.Delete(t);
        }

        public List<Branch> TGetAll()
        {
            return _branchDal.GetAll();
        }

        public Branch TGetByID(int id)
        {
            return _branchDal.GetByID(id);
        }

        public void TUpdate(Branch t)
        {
            _branchDal.Update(t);
        }
    }
}
