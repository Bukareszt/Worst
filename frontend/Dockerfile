FROM node
WORKDIR /app

COPY ./package.json ./
COPY ./package-lock.json ./

RUN npm install --silent


COPY . ./

ENTRYPOINT ["npm","start"]
