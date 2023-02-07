using PulsarModLoader.SaveData;
using System.IO;
using static Randomizer.Mod;

namespace Randomizer
{
    internal class SaveManager : PMLSaveData
    {
        public override uint VersionID => 72;

        public override void LoadData(byte[] Data, uint VersionID)
        {
            using (MemoryStream dataStream = new MemoryStream(Data))
            {
                using (BinaryReader binaryReader = new BinaryReader(dataStream))
                {
                    Configs.level = binaryReader.ReadBoolean();
                    Configs.bossitem = binaryReader.ReadBoolean();
                    Configs.shouldlevel = binaryReader.ReadBoolean();
                    Configs.times = binaryReader.ReadInt32();
                    Configs.limit = binaryReader.ReadInt32();
                    Configs.randomship = binaryReader.ReadBoolean();
                    Configs.shouldrandomship = binaryReader.ReadBoolean();
                    Configs.randomjump = binaryReader.ReadBoolean();
                    Configs.currentjump = binaryReader.ReadInt32();
                    Configs.jumpmax = binaryReader.ReadInt32();
                }
            }
        }

        public override byte[] SaveData()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(stream))
                {
                    binaryWriter.Write(Configs.level);
                    binaryWriter.Write(Configs.bossitem);
                    binaryWriter.Write(Configs.shouldlevel);
                    binaryWriter.Write(Configs.times);
                    binaryWriter.Write(Configs.limit);
                    binaryWriter.Write(Configs.randomship);
                    binaryWriter.Write(Configs.shouldrandomship);
                    binaryWriter.Write(Configs.randomjump);
                    binaryWriter.Write(Configs.currentjump);
                    binaryWriter.Write(Configs.jumpmax);
                }
                return stream.ToArray();
            }
        }

        public override string Identifier()
        {
            return "pokegustavo.randomizer";
        }
    }
}
