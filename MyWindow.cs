using JetBrains.Application;
using JetBrains.DataFlow;
using JetBrains.ReSharper.Features.Navigation.Resources;
using JetBrains.UI.ActionsRevised;
using JetBrains.UI.CrossFramework;
using JetBrains.UI.MenuGroups;
using JetBrains.UI.ToolWindowManagement;

namespace Localized_RS91_Minimal
{
    [Action(ActionId, "MyAction", Id = 21340987)]
    public class MyToolWindowAction : ActivateToolWindowActionHandler<MyToolWindowDescriptor>
    {
        public const string ActionId = "MyAction";
    }

    [ActionGroup(Id, ActionGroupInsertStyles.Submenu, Id = 12345678, Text = "My Stuff")]
    public class MyMenu : IAction, IInsertLast<VsMainMenuGroup>
    {
        public const string Id = "KaVE.Menu";

        public MyMenu(MyToolWindowAction a)
        {
        }
    }

    [ToolWindowDescriptor(
        ProductNeutralId = "SessionManagerFeedbackWindow",
        Text = "Event Manager",
        Type = ToolWindowType.SingleInstance,
        VisibilityPersistenceScope = ToolWindowVisibilityPersistenceScope.Global,
        Icon = typeof (FeaturesFindingThemedIcons.SearchOptionsPage), // TODO Replace with own icon
        InitialDocking = ToolWindowInitialDocking.Bottom, // TODO make it dock!
        InitialHeight = 400,
        InitialWidth = 1000
        )]
    public class MyToolWindowDescriptor : ToolWindowDescriptor
    {
        public MyToolWindowDescriptor(IApplicationHost host) : base(host)
        {
        }
    }

    [ShellComponent]
    public class MyToolWindowRegistrar
    {
        public MyToolWindowRegistrar(Lifetime lifetime, ToolWindowManager toolWindowManager,
            MyToolWindowDescriptor descriptor)
        {
            var toolWindowClass = toolWindowManager.Classes[descriptor];
            toolWindowClass.RegisterEmptyContent(lifetime, lt =>
            {
                var window = new MyToolWindow();
                var wrapper = new EitherControl(window);
                return wrapper.BindToLifetime(lt);
            });
        }
    }
}