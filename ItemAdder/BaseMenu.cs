using System;

namespace ItemAdder
{
    class BaseMenu
    {
        protected ItemAdder ItemAdder;

        public BaseMenu(ItemAdder itemadder)
        {
            this.ItemAdder = itemadder;
        }


        virtual public void Run()
        {
            // Overridea virtuella menyerna
        }
    }
}