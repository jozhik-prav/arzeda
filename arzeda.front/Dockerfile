FROM node:15-alpine

WORKDIR /app

COPY . .

RUN npm install

EXPOSE 8080

ENTRYPOINT ["npm", "run", "dev"]