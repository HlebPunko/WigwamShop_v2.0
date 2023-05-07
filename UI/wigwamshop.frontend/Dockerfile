FROM node:18.13.0-alpine
WORKDIR /app
COPY ./UI/wigwamshop.frontend ./
RUN npm install
COPY . .
CMD ["npm", "start"]