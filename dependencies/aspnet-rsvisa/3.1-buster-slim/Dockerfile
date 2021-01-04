FROM mcr.microsoft.com/dotnet/aspnet:3.1-buster-slim

RUN apt-get update

# notice: run this file two levels above (see build.sh)
COPY ["./rsvisa-runtime/5.12.3/rsvisa-runtime_5.12.3_amd64.deb", "/home/"]
RUN apt install -y --no-install-recommends /home/rsvisa-runtime_5.12.3_amd64.deb

# cleanup
RUN rm /home/rsvisa-runtime_5.12.3_amd64.deb \
    && rm -rf /var/lib/apt/lists/*