using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TryCommand
{
    public class TryCommand : MonoBehaviour
    {

        //InvokerがCommandを受け取り、コマンド実行する。
        //その時内部のcommandで渡されたReceiverが実際にコマンドの中身を実行する

        void Start()
        {
            JumpBehaveReceiver jumpBehaverReceiver = new JumpBehaveReceiver();
            JumpCommand jumpCommand = new JumpCommand(jumpBehaverReceiver);
            CommandInvoker invoker = new CommandInvoker();

            invoker.SetCommand(jumpCommand);
            invoker.ExecuteCommand();
        }

    }

    interface ICommandReceiver
    {
        void CommandAction();
    }
    abstract class Command
    {
        protected ICommandReceiver _receiver;

        public Command(ICommandReceiver r)
        {
            _receiver = r;
        }

        public abstract void Execute();
    }

    class JumpCommand : Command
    {
        public JumpCommand(JumpBehaveReceiver r) : base(r)
        {

        }

        public override void Execute()
        {
            _receiver.CommandAction();
        }
    }
    class JumpBehaveReceiver : ICommandReceiver
    {
        public void CommandAction()
        {
            Debug.Log("Jump!");
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
}


