using System;
using System.Collections.Generic;
using System.Text;
using WpfApp13.Models;

namespace WpfApp13.Events
{
    public class TodoRemovedEvent : PubSubEvent<TodoItem>
    {

    }
}
