# phpuploaderCS

![phpuploader](http://teamwind.serveblog.net/github/phpuploader/phpuploader.jpg)

�{�v���W�F�N�g�́AC# .net�ɂ��T�[�o�[�T�C�h�̕ێ�c�[���ł��B  
�w��t�H���_��zip(password�t)���w��T�C�Y�ŕ�����A���T�[�o�[�փA�b�v���[�h(php)���o�b�N�A�b�v���Ă��܂��B  
  
�������e�́A  
1.�w��t�H���_��zip�B  
2.���ׂ̂�����Ȃ��T�C�Y�̕����t�@�C���ɃJ�b�g�B  
3.����php�T�[�o�[�փA�b�v���[�h���Ă��܂��B  
4.php�T�[�o�[���Ō������ۊǁBphp���Y�t���Ă��܂��B(receive.php)  
5.�ȏ������܂��͑������s�B  
�ȏ�ł��B  
  
�����⑫����  
����������ʂ̌���ō쐬�������L�v���W�F�N�g�����J���ł��B��낵����΂�����̃��|���g�W���������������B  
phpuploader basic��  
phpuploaderNJS Node.js��  
  
# Requirement
  
Windows11��ŏ����Ă��܂��B  
nvm�ɂ�nodejs���C���X�g�[���B�����_�ł͉��L�o�[�W�����ł��B  
Visual Studio 2022���g�p���Ă��܂��BVersion 17.14.13 (August 2025)  
.net framework4.8���w�肵�Ă���̂œK�X�ύX���Ă��������B  
zip�́ANuGet��SharpZipLib���C�u�������g�p���Ă��܂��B  
�A�b�v���[�h�́AMicrosoft.VisualBasic.Devices.Network()���g�p���Ă��܂��B[�Q�Ƃ�Microsoft.VisualBasic.dll��ǉ����Ă��܂��B]  
  
�{�v���W�F�N�g�����s���邽�߂�php�T�[�o�[��ʓr�p�ӂ��Ă��������B  
  
# Usage
  
1.�N����A��}�T���v����ʂ��Q�l�ɓ��͗���ݒ肵�Ă��������Bstart�{�^���ŊJ�n���܂��B  
2.�����T�C�Y�́Aphp.ini�́upost_max_size = �v���ƍ��킹�Ē������Ă��������B  
3.�������J�T�[�o�[�Ō��؂���ꍇ�́Aphp�̃t�@�C�����𕡎G����ɂ�����F�؏������ǉ�����ȂǃZ�L�����e�B���������������悢�Ǝv���܂��B  
  
# How It Works
  
  1.���C�������́AbackgroundWorker���ɏ����Ă��܂��B  
  2.���C�������́A�i�v���[�v���Ă��܂��B�O������̃g���K�[�ɂ���ď������J�n���Ă��܂��B  
  3.�g���K�[�́A�������s�Ɠ������s������܂��Btimer���Ńg���K�[�t���O�𐧌䂵�Ă��܂��B    
  4.�����̏ꍇ�́A�ݒ肵��������s�����ƃV�X�e�������r���肵�Ă��܂��B
  5.php�́A��M�����t�@�C����md5�l��prm�Ɣ�r�A�ŏI�t�@�C���Ȃ猋�������Ă��܂��B  

# Tecnical Details
  
1.SharpZipLib��zip�B  
2.�t�@�C����FileStream�ŃJ�b�g�B  
3.md5�擾�B  
4.My.Computer.Network.UploadFile��upload�B  
5.�񓯊������B  
6.�f���Q�[�g��UI�X�V�B  
7.php�A�g�B  
  
# Note
  
���ۂɉ^�p����ꍇ�́A���������Z�L�����e�B�ƃG���[�΍����������K�v������܂��B�T�[�o�[���׌y���̒������K�v�ł��B  
�R�[�h�͂��ׂ�windows�O��ł��B��OS�̓p�X���K�X�ύX���Ă��������B  
�o�O�����邩������܂���B���ȐӔC�ł����p���������B�܂��K�X�R�[�h�ύX���Ă��������B  
���v�]�����������܂����烁�[���������B  
  
# License
  
MIT license�B�I���W�i���R�[�h�̒��쌠�́ATeamwind�ł��B����ȊO�̃��C�u�������̒��쌠�͊e�X�̏��L�҂ɋA�����܂��B  

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

