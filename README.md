# ITLab-Back-Root
Root config for ITLab-back


Services in backend part:
| Service        | Status      | Available on                               | Inner port            |
| -------------- | ----------- | ------------------------------------------ | --------------------- |
| Identity       | Done        | http://127.0.0.1.xip.io:5501               | 5501                  |
| Identity Admin | Done        | http://127.0.0.1.xip.io:5502               | 5502                  |
| Backend        | Done        | http://127.0.0.1.xip.io:5503/api/          | 5503                  |
| DocsGen        | Done        | http://127.0.0.1.xip.io:5503/api/docsgen/  | 8080 (should be 5504) |
| Projects       | Done        | http://127.0.0.1.xip.io:5503/api/projects/ | 5505                  |
| Reports        | Done        | http://127.0.0.1.xip.io:5503/api/reports/  | 5506                  |
| MFS            | Done        | http://127.0.0.1.xip.io:5503/api/mfs/      | 5507                  |
| Salary         | In progress | -                                          | -                     |
| Notify         | In progress | -                                          | -                     |

In local mode, Cookie with same-site ignored on http connection by default in chrome-based browsers. Select **"Disable"** in chrome config `Cookies without SameSite must be secure` chrome://flags/#cookies-without-same-site-must-be-secure

## Build

### Build apps
```bash
./build
```

### Set environment variables:
* ITLABPROJ_GH_ACCESS_TOKEN - Personal Access Token from github for access to private repos on GitHub [link](https://github.com/settings/tokens).

> While developing you can create `env.ps1` or `env.sh` files. They have already been ignored.
> Powershell example
> ```powershell
> $Env:ITLABPROJ_GH_ACCESS_TOKEN='YOUR TOKEN'
> ```
> Bash example
> ```bash
> export ITLABPROJ_GH_ACCESS_TOKEN='YOUR TOKEN'
> ```
> And apply env to current session
> ```bash
> . ./env.ps1
> # or
> . ./env.sh
> ```

### Build docker images

```bash
. ./alias-back.ps1 # alias for docker compose
dbc build --no-cache
```

## Run services

```bash
bdc up -d
```