using System;

namespace Tamagotchi.DataAccess.DataModels
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        DateTime DateCreated { get; set; }
        DateTime LastModified { get; set; }
    }
}