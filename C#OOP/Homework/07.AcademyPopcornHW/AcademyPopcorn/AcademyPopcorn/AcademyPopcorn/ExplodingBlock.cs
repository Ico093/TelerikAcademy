using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ExplodingBlock : Block
    {
        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {

        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (IsDestroyed == true)
            {
                return new List<GameObject>() {  new UnstoppableBall(topLeft,new MatrixCoords(1,0),1),
                                             new UnstoppableBall(topLeft,new MatrixCoords(0,1),1),
                                             new UnstoppableBall(topLeft,new MatrixCoords(0,-1),1)
                                          };
            }
            else
            {
                return new List<GameObject>();
            }
        }
    }
}
