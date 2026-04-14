using System.Collections;
using System.Collections.Generic;
public interface IShipVisitable
{
    void Accept(IShipVisitor visitor);
}