FROM node:18-alpine AS build
WORKDIR /app
COPY package.json package-lock.json ./
RUN npm ci
COPY vite.config.js ./
COPY index.html ./
COPY 404.html ./
COPY public ./public
COPY src ./src
COPY services ./services
COPY work ./work
COPY about ./about
COPY faq ./faq
COPY blog ./blog
COPY contact ./contact
RUN npm run build

FROM nginxinc/nginx-unprivileged:1.27-alpine
COPY --from=build --chown=101:101 /app/dist /usr/share/nginx/html
COPY --chown=101:101 nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 8080
