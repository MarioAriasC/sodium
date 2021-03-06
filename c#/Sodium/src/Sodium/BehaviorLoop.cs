using System;

namespace Sodium
{

  public class BehaviorLoop<TA> : Behavior<TA> where TA : class
  {
    public BehaviorLoop()
      : base(new EventLoop<TA>(), null, resetInitValue: true)
    {
    }

    public void Loop(Behavior<TA> aOut)
    {
      ((EventLoop<TA>)Event).Loop(aOut.Updates());
      EventValue = aOut.Sample();
    }

    public override TA SampleNoTrans()
    {
      if (!_isEventValueSet)
        throw new Exception("BehaviorLoop sampled before it was looped");
      return EventValue;
    }
  }
}
