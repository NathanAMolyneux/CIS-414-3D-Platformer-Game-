using System.Collections;
using System.Collections.Generic;
public interface IShipVisitor
{
    void Visit(PowerPanel panel);
    void Visit(OxygenPanel stabilizer);
    void Visit(NavigationConsole console);
}