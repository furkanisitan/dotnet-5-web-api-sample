using Core.CrossCuttingConcerns.ExceptionHandling;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace Core.Aspects.Postsharp.ExceptionHandlingAspects
{
    [PSerializable]
    public sealed class ExceptionHandleAspect : OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            var exceptionHandler = new ExceptionHandler();
            exceptionHandler.Handle(args);
        }
    }
}
