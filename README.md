# ITLab-Back-Root
Root config for ITLab-back

## Requirement
* .Net core SDK 3.1
* JDK 11+

Services in backend part:
| Service        | Status      | Available on                              | Inner port            |
| -------------- | ----------- | ----------------------------------------- | --------------------- |
| Identity       | Done        | http://127.0.0.1.xip.io:5501              | 5501                  |
| Identity Admin | Done        | http://127.0.0.1.xip.io:5502              | 5502                  |
| Backend        | Done        | http://127.0.0.1.xip.io:5503/api/         | 5503                  |
| DocsGen        | Done        | http://127.0.0.1.xip.io:5503/api/docsgen/ | 8080 (should be 5504) |
| Notify         | In progress | -                                         | -                     |
| Projects       | In progress | -                                         | -                     |
| Reports        | In progress | -                                         | -                     |
| Salary         | In progress | -                                         | -                     |

In local mode, Cookie with same-site ignored on http connection by default in chrome-based browsers. Select **"Disable"** in chrome config `Cookies without SameSite must be secure` chrome://flags/#cookies-without-same-site-must-be-secure

## Build
```bash
# windows
.\build.ps1
# linux
./build.sh
```