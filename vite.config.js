import { resolve } from "node:path";
import { defineConfig } from "vite";

const root = resolve(__dirname);

export default defineConfig({
  build: {
    rollupOptions: {
      input: {
        main: resolve(root, "index.html"),
        services: resolve(root, "services/index.html"),
        work: resolve(root, "work/index.html"),
        about: resolve(root, "about/index.html"),
        faq: resolve(root, "faq/index.html"),
        blog: resolve(root, "blog/index.html"),
        blogPost: resolve(root, "blog/website-basics-for-northwest-pa-small-businesses/index.html"),
        contact: resolve(root, "contact/index.html"),
        notFound: resolve(root, "404.html"),
      },
    },
  },
});
