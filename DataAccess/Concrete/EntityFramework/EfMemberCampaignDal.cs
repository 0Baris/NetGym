﻿using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMemberCampaignDal : EfEntityRepositoryBase<MemberCampaign, NetGymContext>, IMemberCampaignDal
    {   
    }
}