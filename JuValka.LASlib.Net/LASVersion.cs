using System.IO;

namespace JuValka.LASlib.Net
{
    public class LASReadVersion
    {
        public string GetVersion(string Las)
        {
            using (Stream s = new FileStream(Las, FileMode.Open, FileAccess.Read))
            {
                BinaryReader br = new BinaryReader(s);
                br.BaseStream.Seek(0, 0);
                br.ReadBytes(24);
                var VersionMajor = br.ReadByte();
                var VersionMinor = br.ReadByte();
                var version = VersionMajor.ToString() + "." + VersionMinor.ToString();
                return version;
            }
        }
        public string VarHeader(string las)
        {
            LASReadVersion lasVersion = new LASReadVersion();
            var strVer = lasVersion.GetVersion(las);
            return strVer;
        }
    }
}
