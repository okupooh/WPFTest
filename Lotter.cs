using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTest
{
    public enum PrizeNum : int
    {
        PrizeLost = 0,
        Prize1st = 1,
        Prize2nd = 2,
        Prize3rd = 3,
        Prize4th = 4,
        Prize5th = 5
    }
    /// <summary>
    /// 
    /// </summary>
    public class Lotter
    {
        private int m_maxTableSize = 256 ;
        private List<int> m_LotterTable ;
        public Lotter()
        {
            initialize();
        }
    
        public void printLotterTable(){
            for(int i=0 ; i<m_LotterTable.Count ; i++) {
                Debug.WriteLine( "{0} , {1}" ,i ,m_LotterTable[i] ) ;
            }
        }

        public int getPrizeNum(){
            Random rnd = new Random();
            int r = rnd.Next(m_LotterTable.Count);
            return m_LotterTable[r] ;
        }
        
        private void initialize()
        {
            m_LotterTable = new List<int>();
        
            for(int i=0 ; i<m_maxTableSize ; i++) {
                m_LotterTable.Add( (int)PrizeNum.PrizeLost ) ;
            }
        
            createLotterTable((int)PrizeNum.Prize1st,10);
            createLotterTable((int)PrizeNum.Prize2nd,20);
            createLotterTable((int)PrizeNum.Prize3rd,30);
            createLotterTable((int)PrizeNum.Prize4th,40);
            createLotterTable((int)PrizeNum.Prize5th,50);
        
        }
        private void createLotterTable(int value , int count)
        {
            Random rnd = new Random();
            int r ;
            int i = 0;
            while( i < count ) {
                r = rnd.Next(m_LotterTable.Count);
                if ( m_LotterTable[r] == (int)PrizeNum.PrizeLost ) {
                    m_LotterTable[r] = value ;
                    i++ ;
                }
            }
        }

    }
}