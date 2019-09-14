using System;

namespace Dodger.Core.Entities.Components.PhysicsComponent
{
    public interface IPhysicsComponent : IInteractingGameObject
    {
        void Update(IInteractingGameObject gameObject);
        event EventHandler LocationChanged;
    }
}