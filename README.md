# phpuploaderCS

(Translation by Google)

This is a data backup tool between Windows servers.
I use it to exchange data between my personal main/backup servers.
The functions of this exe are:
1. Zip the specified folder.
2. Cut into multiple files of a size that does not put a load on the server.
3. Sequentially send to other servers.
4. Execute the above daily or immediately.

The technique being used.
1. Zip the specified folder using SharpZipLib.
2. Cut into multiple files using FileStream.
3. Send using My.Computer.Network.UploadFile.
4. Execute using Task.Run.
5. Use a simple PHP script to receive the files.
6. Merge the received files using PHP.
7. Use md5 to check the integrity of the files.
8: Use delegates to update the UI.

Visual Basic version is also available.

windows�T�[�o�[�Ԃ̃f�[�^�o�b�N�A�b�v�c�[���ł��B  
�l�ŉ^�p���Ă���{/�\���T�[�o�[���m�̃f�[�^�����Ɏg�p���Ă��܂��B  
�{exe�̋@�\�́A  
1.�w��t�H���_��zip�B  
2.���ׂ̂�����Ȃ��T�C�Y�̕����t�@�C���ɃJ�b�g�B  
3.�������T�[�o�[�֑��M���Ă��܂��B  
4.�ȏ������܂��͑������s�B  

�g�p���Ă���e�N�j�b�N�B
1. �w��t�H���_��SharpZipLib��zip�B
2. ���ׂ̂�����Ȃ��T�C�Y�̕����t�@�C����FileStream�ŃJ�b�g�B
3. ����My.Computer.Network.UploadFile�ő��M�B
4. Task.Run�Ŏ��s�B
5. �Ȉ�PHP�X�N���v�g�Ńt�@�C����M�B
6. ��M�����t�@�C����PHP�Ō����B
7. md5�Ńt�@�C���̐������`�F�b�N�B
8. �f���Q�[�g���g�p���āAUI�̍X�V���s���B

Visual Basic�ł����J���Ă��܂��B

# Requirement
Visual Studio 2019 or later.
Nothing in particular. It will work on Windows.
.Net Framework 4.8 is specified, so please change it as appropriate.
For zipping, I use the SharpZipLib library on NuGet.
For uploading, I use My.Computer.Network.UploadFile.
PHP is required on the receiving side. However, the following PHP code is based on Windows.

���ɂ���܂���Bwindows�ł���Γ����܂��B  
.net framework4.8���w�肵�Ă���̂œK�X�ύX���Ă��������B  
zip�́ANuGet��SharpZipLib���C�u�������g�p���Ă��܂��B
�A�b�v���[�h�́AMy.Computer.Network.UploadFile���g�p���Ă��܂��B
��M���́Aphp�K�{�ł��B�������Lphp��windows�O��R�[�h�ł��B  

# License
MIT license. Copyright: Teamwind.
zip uses the SharpZipLib library.

MIT license�B���쌠�́ATeamwind�ł��B  
zip�́ASharpZipLib���C�u�����g�p�B

# Note
There may be bugs. Use at your own risk. Also, modify the code accordingly.
If you have any requests, please email us. 

�o�O�����邩������܂���B���ȐӔC�ł����p���������B�܂��K�X�R�[�h�ύX���Ă��������B
���v�]�����������܂����烁�[���������B

This is a sample php. �ȉ��T���v��php�ł��B  

# PHP
    //php start
    
    //sample php for phpuploader. phpuploader�preceivesample php
    //Split file reception and merging process. �����t�@�C����M��������

    //this store them by day of the week, meaning keep a 7-day supply.
    //�j�����Ƃɕۊǂ��Ă��܂��B�܂�7�����ێ����Ă��܂��B

    //Please change each setting as appropriate.
    //�e�ݒ�́A�K�X�ύX���Ă��������B

    //MIT license (c)teamwind n.h

    //(Translation by Google)

    //Storage directory. �ۊ�dir
    //for windows
    $storagedir = "c:\\backup\\";

    //?
    if($_FILES["file"]["tmp_name"]==""){
        throw new \Exception($dir.$zipname."?no file");
        exit;
    }

    //Sub-dir name of storage dir. �ۊ�dir�̉���dir��
    $week = array('sun','mon','tue','wed','thu','fri','sat');

    $date = date('w');

    //prm analysis. prm���
    $prms = explode(',', mb_convert_encoding($_GET["prm"], "SJIS", "UTF-8"));

    //prm=zip File name+Division Number(000-nnn),Division Number(000-nnn),Final division number,this md5,zip md5
    //prm=zip�t�@�C����+�����ԍ�,�����ԍ�,�ŏI�����ԍ�,���Ymd5,��������zip��md5
    //abc.zip.000,2,xxxxxxxxxxxxxxxxxxxx(md5),xxxxxxxxxxxxxxxxxxxx(md5)
    //abc.zip.001,2,xxxxxxxxxxxxxxxxxxxx(md5),xxxxxxxxxxxxxxxxxxxx(md5)
    //abc.zip.002,2,xxxxxxxxxxxxxxxxxxxx(md5),xxxxxxxxxxxxxxxxxxxx(md5)
    $_sepname = $prms[0];
    $_no = (int)$prms[1];
    $_lastno = (int)$prms[2];
    $_md5 = $prms[3];
    $_zipmd5 = $prms[4];

    //Create a storage directory. �ۊ�dir�̐���
    $dir = $storagedir."\\".$week[$date]."\\";
    if(file_exists($dir)){
    }else{
        mkdir($dir, 0777, true);
    }
    //move file. �ړ�
    move_uploaded_file($_FILES["file"]["tmp_name"], $dir.$_sepname);

    //md5 check. md5�`�F�b�N
    $md5 = md5_file($dir.$_sepname);
    if($_md5 === $md5){
    } else {
        throw new \Exception($dir.$_sepname."md5 error");
    }

    //If it is the last file, start joining. �����ŏI�t�@�C���Ȃ猋���J�n
    if($_no == $_lastno){

        //Zip file name without [.nnn]. zip file����[.nnn]������������   abc.zip.000
        $zipname = substr($_sepname, 0, strlen($_sepname)-4);

        //Generate a file list. �t�@�C�����X�g�𐶐�����
        //abc.zip.000
        //abc.zip.001
        //abc.zip.002
        for($i = 0; $i <= $_lastno; $i++){
            $files[$i] = $dir.$zipname.".".sprintf("%03d", $i);
        }

        //Combine these. ����������
        if($_lastno == 0){
            //If it's single, it's just a copy. �P��Ȃ炽���̃R�s�[
            copy($dir.$_sepname, $dir.$zipname);
            unlink($dir.$_sepname);
        } else {
            //Destination file name. �o�͐�̃t�@�C����
            $outputFile = $dir.$zipname;

            //Open the output file. �o�̓t�@�C�����J��
            $outputHandle = fopen($dir.$zipname, 'wb');
            if(!$outputHandle){
                //NG
            } else {
                //join. ����
                //Read each file in turn and combine them.  �e�t�@�C�������Ԃɓǂݍ���Ō���
                foreach ($files as $file) {
                    if (!file_exists($file)) {
                        continue;
                    }
                    $inputHandle = fopen($file, 'rb');
                    if (!$inputHandle) {
                        continue;
                    }
                    //Read the file contents and write them to the output file.  �t�@�C�����e��ǂݍ���ŏo�̓t�@�C���ɏ�������
                    while(!feof($inputHandle)) {
                        //64kbyte
                        $buffer = fread($inputHandle, 65536);
                        fwrite($outputHandle, $buffer);
                    }
                    fclose($inputHandle);
                    //Erase the original. ��������
                    unlink($file);
                }
                //Close the output file.  �o�̓t�@�C�������
                fclose($outputHandle);
                //md5 check. md5�`�F�b�N
                $md5 = md5_file($dir.$zipname);
                if($_zipmd5 === $md5){
                } else {
                    throw new \Exception($dir.$zipname."md5 error);
                }
            }
        }
    }

    //php end

    <form action="./receive.php" method="POST" enctype="multipart/form-data"> 
      <input type="file" name="file"> 
      <input type="submit" value="phpuploader sample php"> 
    </form> 

