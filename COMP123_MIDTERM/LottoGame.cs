using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP123_MIDTERM
{
    /**
         * <summary>
         * This abstract class is a blueprint for all Lotto Games
         * </summary>
         * 
         * @class LottoGame
         * @jaskirat {int} ElementNum;
         * @jaskirat {int} SetSize;
         */
    public abstract class LottoGame
    {
        // PRIVATE INSTANCE VARIABLES +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        // CREATE private fields here --------------------------------------------
        private List<int> jk_elememntList;
        private int jk_elementNumber;
        private List<int> jk_numberList;
        private Random jk_random;
        private int jk_setSize;
        // PUBLIC PROPERTIES ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        // CREATE public properties here -----------------------------------------
        /*
         * The ElementList property contain the random number generated from the NUmberList.
         * The ElementNumber property stores the times of random number needed to generate.
         */
        public List<int> ElementList
        {
            get
            {
                return this.jk_elememntList;
            }
        }
        public int ElementNumber
        {
            get
            {
                return this.jk_elementNumber;
            }

            set
            {
                this.jk_elementNumber = value;
            }

        }
        public List<int> NumberList
        {
            get
            {
                return this.jk_numberList;
            }

        }
        public Random random
        {
            get
            {
                return this.jk_random;
            }
        }

        public int SetSize
        {
            get
            {
                return this.jk_setSize;
            }

            set
            {
                this.jk_setSize = value;
            }
        }
        // CONSTRUCTORS +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        /**
         * <summary>
         * This constructor takes two parameters: elementNumber and setSize
         * The elementNumber parameter has a default value of 6
         * The setSize parameter has a default value of 49
         * </summary>
         * 
         * @constructor LottoGame
         * @jaskirat {int} elementNumber
         * @jaskirat {int} setSize
         */
        public LottoGame(int elementNumber = 6, int setSize = 49)
        {
            // assign elementNumber local variable to the ElementNumber property
            this.ElementNumber = elementNumber;

            // assign setSize local variable to the SetSize property
            this.SetSize = setSize;

            // call the _initialize method
            this._initialize();

            // call the _build method
            this._build();
        }

        // PRIVATE METHODS ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        // CREATE the private _initialize method here -----------------------------
        private void _initialize()
        {
            this.jk_elememntList = new List<int>();
            this.jk_numberList = new List<int>();
            this.jk_random = new Random();
        }
        // CREATE the private _build method here -----------------------------------
        private void _build()
        {
            for (int i = 0; i < SetSize; i++)
            {
                NumberList.Add(i + 1);

            }
        }
        // OVERRIDEN METHODS ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        /**
         * <summary>
         * Override the default ToString function so that it displays the current
         * ElementList
         * </summary>
         * 
         * @override
         * @method ToString
         * @returns {string}
         */
        public override string ToString()
        {
            // create a string variable named lottoNumberString and intialize it with the empty string
            string lottoNumberString = String.Empty;

            // for each lottoNumber in ElementList, loop...
            foreach (int lottoNumber in ElementList)
            {
                // add lottoNumber and appropriate spaces to the lottoNumberString variable
                lottoNumberString += lottoNumber > 9 ? (lottoNumber + " ") : (lottoNumber + "  ");
            }

            return lottoNumberString;
        }

        // PUBLIC METHODS +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        // CREATE the public PickElements method here ----------------------------
        public void PickElements()
        {
            if (ElementList.Count > 0)
            {


                ElementList.Clear();
                NumberList.Clear();
                this._build();
            }

            for (int i = 0; i < ElementNumber; i++)
            {

                int Number = jk_random.Next(NumberList.Count);

                ElementList.Add(NumberList[Number]);
                NumberList.RemoveAt(Number);


            }

            ElementList.Sort();
        }
    }
}
