namespace DotDED
{
    public class File
    {
        public byte version;
        public bool executable;
        public bool readOnly;
        public bool encrypted;
        public bool hasKey;
        public string creator = "";
        public File(string path) {
            FileStream fs = new(path, FileMode.Open);
            int len = (int)fs.Length;
            byte[] buffer = new byte[2];
            if (len < 3) {throw new FileFormatException("No size for 0xDED0 header.");}
            fs.Read(buffer, 0, 2);
            if (buffer[0]!= 0xDE || buffer[1]!= 0xD0) {throw new FileFormatException("0xDED0 header does not match.");}
            if (len < 4) {throw new FileFormatException("No version byte.");}
            fs.Read(buffer, 2, 1);
            version = buffer[0];
            if (version!=1) {throw new FileFormatException("Version not supported.");}
            if (len < 5) {throw new FileFormatException("No flags byte.");}
            fs.Read(buffer, 3, 1);
            executable = (buffer[0] & (1 << 0)) != 0;
            readOnly = (buffer[0] & (1 << 1)) != 0;
            encrypted = (buffer[0] & (1 << 2)) != 0;
            hasKey = (buffer[0] & (1 << 3)) != 0;
            if (len < 6) {throw new FileFormatException("No creator length byte.");}
            fs.Read(buffer, 4, 1);
            byte creatorlength = buffer[0];
            if (creatorlength!=0) {
                if (len < 6+creatorlength) {throw new FileFormatException("Creator length exceeds file size.");}
                byte[] creatorbytes = new byte[creatorlength];
                fs.Read(creatorbytes, 5, creatorlength);
                creator = System.Text.Encoding.ASCII.GetString(creatorbytes);
            }
            
        }
    }
}