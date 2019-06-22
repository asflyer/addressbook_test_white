using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using System.Windows.Automation;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.InputDevices;
using TestStack.White.WindowsAPI;

namespace addressbook_test_white
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }


        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue = OpenGroupsDialogue();

            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");

            TreeNode root = tree.Nodes[0];

            foreach(TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });
            }

            ClosGroupsDialogue(dialogue);
            return list;
        }

        /*internal GroupData RemoveGroup(int v, GroupData group)
        {
            OpenGroupsDialogue();

            aux.ControlTreeView(GROUPWINTITLE,"", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", "#0|#" + v, "");//Select Group to Remove
            group.Name = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", "#0|#" + v, "");
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");//Click to DELETE
            aux.WinWait("Delete group");//Wait for open window

            aux.ControlClick("Delete group", "", "WindowsForms10.BUTTON.app.0.2c908d51");//Click to "Delete the selected Group"
                        
            aux.ControlClick("Delete group", "", "WindowsForms10.BUTTON.app.0.2c908d53");//Click to "OK"

            ClosGroupsDialogue();
            return group;
        }*/
       
        public void Add(GroupData newGroup)
        {
            Window dialogue = OpenGroupsDialogue();

            dialogue.Get<Button>("uxNewAddressButton").Click();

            TextBox textBox = (TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

            //aux.Send("{ENTER}");
            ClosGroupsDialogue(dialogue);

        }

        private void ClosGroupsDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();
        }

        private Window OpenGroupsDialogue()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
             
         }
    }
}