FROM bunkfer/pyqt5:3.13.3-slim

WORKDIR /app


RUN mkdir -p /app/modelos

COPY . .

#VOLUME [ "/app/modelos" ]
CMD [ "python3", "main.py" ]