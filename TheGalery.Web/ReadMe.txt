To debug OneDrive auth:
1)
Add the following line to %WinDir%\system32\drivers\etc\hosts
127.0.0.1    yaeldayanphoto.azurewebsites.net

2)
Run the below (as admin) to bind the site fqdn (yaeldayanphoto.azurewebsites.net) to the project (TheGalery.Web):
cd /d "%ProgramFiles%\IIS Express"
appcmd.exe set config -section:system.applicationHost/sites /-"[name='TheGalery.Web'].bindings.[protocol='http',bindingInformation='*:80:yaeldayanphoto.azurewebsites.net']" /commit:apphost

3)
On project's properties, select the Web tab, set Project Url to the site url (http://yaeldayanphoto.azurewebsites.net/)

More details;,
http://www.asp.net/web-api/overview/security/external-authentication-services#FQDN