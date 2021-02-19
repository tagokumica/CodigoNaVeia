using Domain.Interface.Notification;
using Domain.Notification;
using FluentValidation;
using FluentValidation.Results;

namespace Domain.Service
{
    public abstract class BaseService
    {

        private readonly INotification _iNotification;

        protected BaseService(INotification iNotification)
        {
            _iNotification = iNotification;
        }


        protected void Notify(string message)
        {
            _iNotification.Handle(new Notifier(message));
        }


        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected bool IsValid()
        {
           return _iNotification.HaveNotifier();
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : class
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid)
                return true;

            Notify(validator);

            return false;
        }
    }
}