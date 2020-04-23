using strange.extensions.mediation.impl;

public class StaffLineMediator : Mediator
{
    [Inject] public StaffLineView view { get; set; }
}