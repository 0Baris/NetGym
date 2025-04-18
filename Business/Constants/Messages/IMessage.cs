namespace Business.Constants.Messages
{
    public interface IMessage
    {
        string CampaignAdded { get; }
        string CampaignUpdated { get; }
        string CampaignDeleted { get; }

        string DealerMemberAdded { get; }
        string DealerMemberUpdated { get; }
        string DealerMemberDeleted { get; }

        string DealerAdded { get; }
        string DealerUpdated { get; }
        string DealerDeleted { get; }

        string EquipmentAdded { get; }
        string EquipmentUpdated { get; }
        string EquipmentDeleted { get; }

        string GymAccessLogAdded { get; }
        string GymAccessLogUpdated { get; }
        string GymAccessLogDeleted { get; }

        string GymCapacityAdded { get; }
        string GymCapacityUpdated { get; }
        string GymCapacityDeleted { get; }

        string MemberCampaignAdded { get; }
        string MemberCampaignUpdated { get; }
        string MemberCampaignDeleted { get; }

        string MemberMeasurementAdded { get; }
        string MemberMeasurementUpdated { get; }
        string MemberMeasurementDeleted { get; }

        string MemberAdded { get; }
        string MemberUpdated { get; }
        string MemberDeleted { get; }

        string PackageAdded { get; }
        string PackageUpdated { get; }
        string PackageDeleted { get; }

        string PaymentAdded { get; }
        string PaymentUpdated { get; }
        string PaymentDeleted { get; }

        string RoleAdded { get; }
        string RoleUpdated { get; }
        string RoleDeleted { get; }

        string SubscriptionAdded { get; }
        string SubscriptionUpdated { get; }
        string SubscriptionDeleted { get; }

        string TrainerAssignmentAdded { get; }
        string TrainerAssignmentUpdated { get; }
        string TrainerAssignmentDeleted { get; }

        string TrainerAdded { get; }
        string TrainerUpdated { get; }
        string TrainerDeleted { get; }

        string TrainerScheduleAdded { get; }
        string TrainerScheduleUpdated { get; }
        string TrainerScheduleDeleted { get; }

        string UserRoleAdded { get; }
        string UserRoleUpdated { get; }
        string UserRoleDeleted { get; }

        string UserAdded { get; }
        string UserUpdated { get; }
        string UserDeleted { get; }

        string ErrorOccurred { get; }
        string NotFound { get; }
        string ValidationFailed { get; }
        string UnauthorizedAccess { get; }
        string OperationFailed { get; }
    }
}
