using PlayChain.Chain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayChain.Chain.Models
{
    public class Chain
    {
        private const long InitialSyply = 2000000;
        private bool _isGenesisOver { get; set; } = false;

        public long InitialSuply { get { return InitialSyply; } }

        public List<Block> Blocks { get; }

        public string TryAddBlock(Block block)
        {
            var lastBlock = GetLastBlock();
            if(lastBlock != null)
            {
                if (lastBlock.BlockId >= block.BlockId)
                {
                    return string.Format(MessagesHelper.ExistingBlock, block.BlockId);
                }
                else
                {
                    Blocks.Add(lastBlock);
                    return MessagesHelper.BlockAdded;
                }
            }
            else
            {
                Blocks.Add(block);
                return MessagesHelper.BlockAdded;
            }
            
        }

        public bool IsGenesisOver { get { return _isGenesisOver; } }

        public Block GetLastBlock()
        {
            Block lastBlock = null;
            try
            {
                lastBlock = Blocks[Blocks.Count - 1];
            }
            catch(Exception ex)
            {
                return null;
            }
            return lastBlock;
        }
        public Block GetFirst()
        {
            Block lastBlock = null;
            try
            {
                lastBlock = Blocks[0];
            }
            catch (Exception ex)
            {
                return null;
            }
            return lastBlock;
        }
        public Block GetNthBlock(int blockId)
        {
            throw new NotImplementedException();
        }
        public string CallGenesisBlock()
        {
            if(_isGenesisOver)
            {
                return MessagesHelper.GenesisBlockIsOver;
            }
            //TODO:
            this._isGenesisOver = true;
            return MessagesHelper.GenesisBlockIsCreated;
        }

        ////private string RecordState()
        //{

        //}

        
    }
}
