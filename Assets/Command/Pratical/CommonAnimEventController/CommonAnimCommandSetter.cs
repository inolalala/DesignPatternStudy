using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CommonAnimCommandSetter : MonoBehaviour {

    #region Private Fields
    [SerializeField] private UnityEvent onAnimStartEvent;
    [SerializeField] private UnityEvent onAnimCompleteEvent;

    private OnAnimStartReceiver onAnimStartReceiver;
    private OnAnimStartCommand onAnimStartCommand;
    private OnAnimCompleteReceiver onAnimCompleteReceiver;
    private OnAnimCompleteCommand onAnimCompleteCommand;
    private CommandInvoker commandInvoker;
    #endregion

    #region Public Methods
    public void SwitchReceiver(Command targetCommand, ICommandReceiver targetReceiver)
    {
        targetCommand.SwitchReceiver(targetReceiver);
    }
    #endregion

    #region Private Methods
    private void initialize()
    {
        onAnimStartReceiver = new OnAnimStartReceiver();
        onAnimStartCommand = new OnAnimStartCommand(onAnimStartReceiver);
        onAnimCompleteReceiver = new OnAnimCompleteReceiver();
        onAnimCompleteCommand = new OnAnimCompleteCommand(onAnimCompleteReceiver);

        commandInvoker = new CommandInvoker();
    }
    #endregion

    #region Animation Events
    private void OnAnimStart()
    {
        commandInvoker.SetCommand(onAnimStartCommand);
        commandInvoker.ExecuteCommand();
    }
    public void OnAnimConplete()
    {
        commandInvoker.SetCommand(onAnimCompleteCommand);
        commandInvoker.ExecuteCommand();
    }
    #endregion

    #region Monobehavior Messages
    void Start()
    {
        initialize();
    }
    #endregion

}

public interface ICommandReceiver
{
    void AnimCommandAction();
}
public abstract class Command
{
    protected ICommandReceiver _receiver;

    public Command(ICommandReceiver r)
    {
        _receiver = r;
    }

    public void SwitchReceiver(ICommandReceiver r)
    {
        _receiver = r;
    }

    public abstract void Execute();
}

class OnAnimStartCommand : Command
{
    public OnAnimStartCommand(OnAnimStartReceiver r) : base(r)
    {

    }

    public override void Execute()
    {
        _receiver.AnimCommandAction();
    }
}
class OnAnimStartReceiver : ICommandReceiver
{
    public void AnimCommandAction()
    {
        Debug.Log("AnimCommandAction!");
    }
}

class OnAnimCompleteCommand : Command
{
    public OnAnimCompleteCommand(OnAnimCompleteReceiver r) : base(r)
    {

    }

    public override void Execute()
    {
        _receiver.AnimCommandAction();
    }
}
class OnAnimCompleteReceiver : ICommandReceiver
{
    public void AnimCommandAction()
    {
        Debug.Log("AnimCommandAction!");
    }
}

class CommandInvoker
{
    private Command _command;

    public void SetCommand(Command command)
    {
        this._command = command;
    }

    public void ExecuteCommand()
    {
        _command.Execute();
    }
}
