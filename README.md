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


