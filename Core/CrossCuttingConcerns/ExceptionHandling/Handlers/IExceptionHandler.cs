using PostSharp.Aspects;

namespace Core.CrossCuttingConcerns.ExceptionHandling.Handlers
{
    interface IExceptionHandler
    {
        void Execute(MethodExecutionArgs args);
    }
}
