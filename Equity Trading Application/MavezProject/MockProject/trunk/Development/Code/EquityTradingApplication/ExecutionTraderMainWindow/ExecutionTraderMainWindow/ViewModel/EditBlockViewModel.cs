using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExecutionTraderDataAccessLayer;
using ExecutionTraderMainWindow.Model;
using ExecutionTraderMainWindow.Helpers;
using System.Windows.Input;
using ExecutionTraderMainWindow.Commands;

namespace ExecutionTraderMainWindow.ViewModel
{
    public class EditBlockViewModel
    {
        public BlockModel SelectedBlock { get; set; }

        public List<BlockModel> SelectedBlockList { get; set; }


        private ICommand deleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                    deleteCommand = new RelayCommand(p=> DeleteOrder());
                return deleteCommand;
            }
        }

        private object DeleteOrder()
        {
            throw new NotImplementedException();
        }

        public EditBlockViewModel(BlockModel selectedBlock)
        {
            this.SelectedBlock = selectedBlock;
            SelectedBlockList = new List<BlockModel>();
            SelectedBlockList.Add(SelectedBlock);
        }
    }
}
