# Adding a new blog post

The blog has no CMS — every post is a static HTML file. Follow these steps
exactly, in order, so every post stays consistent with the rest of the site.
Use `blog/website-basics-for-northwest-pa-small-businesses/index.html` as the
literal template to copy from.

## 1. Create the post file

`blog/<url-slug>/index.html` — slug is lowercase, hyphenated, descriptive
(matches the existing `website-basics-for-northwest-pa-small-businesses`
pattern).

Copy the existing post file as a starting point and update, in this order:

1. `<meta name="description">` — one or two sentences, no fabricated claims.
2. `<title>` — `Post Headline — Stanish Labs`
3. `<link rel="canonical">` — `https://stanishlabs.com/blog/<slug>/`
4. `og:url`, `og:title`, `og:description` — title/description mirror the
   `<title>`/description above; `og:image` stays `/og-image.svg` unless the
   post has its own image.
5. `twitter:title`, `twitter:description`, `twitter:image` — same values as
   the `og:*` tags.
6. The `BlogPosting` JSON-LD block — update `headline`, `description`,
   `datePublished` (real publish date, `YYYY-MM-DD`), and
   `mainEntityOfPage` to the new canonical URL. `author` stays
   `{"@type":"Person","name":"Caleb Stanish"}` unless that changes.
7. Header/nav/footer markup — copy verbatim, do not hand-edit the inline
   SVG logo or nav links.
8. Post header inside `#main-content` — update the `post-meta` date/byline
   line and the `<h1>`.
9. Body copy inside `.post-body` — plain `<p>`, `<h2>`, `<ul>` only. No
   invented facts, prices, testimonials, or claims about Caleb that aren't
   already established elsewhere on the site (no phone number — email +
   service area only, per standing site policy).
10. Keep the closing `.contact.cta-only` section as-is — every post ends
    with the same call-to-action block linking to `/contact/`.

## 2. Add it to the blog index

In `blog/index.html`, add a new `<article class="blog-card reveal">` entry
at the **top** of `.blog-list` (newest first), matching the existing card's
structure: date, linked `<h3>`, one-sentence teaser, "Read the post ↗" link.

## 3. Wire it into the build

- `vite.config.js` — add a new entry under `rollupOptions.input`, e.g.
  `blogPostSlug: resolve(root, "blog/<slug>/index.html")`.
- `Dockerfile` — the `COPY blog ./blog` line already copies the whole
  `blog/` directory recursively, so a new post subdirectory doesn't need a
  new `COPY` line. Only add one if the post lives outside `blog/`.

## 4. Update the sitemap

Add a `<url>` entry for `https://stanishlabs.com/blog/<slug>/` to
`public/sitemap.xml`, matching the existing blog post entry's priority and
changefreq.

## 5. Build and deploy

```bash
npm run build
docker compose up -d --build homepage
```

Then verify:
- `curl -s -o /dev/null -w "%{http_code}\n" http://10.10.20.102:18092/blog/<slug>/` → `200`
- The post appears on `/blog/` and renders correctly in the browser.
