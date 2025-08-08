<%* 
const initialFrontmatter = {
	title: "",
	datetime: moment().toJSON(),
	tags: ["audit/architecture"],
	icon: 'LiPen'
};

initialFrontmatter.title = await tp.system.prompt("Brief name for this audit note");

tp.hooks.on_all_templates_executed(async () => {
    tp.app.fileManager.processFrontMatter(file, (frontmatter) => {
        for (const key of Object.keys(initialFrontmatter)) {
            frontmatter[key] = initialFrontmatter[key];
        }
    })
})

if (tp.config.run_mode === 0) {
	await tp.file.move(`Cadmium/Architecture/Thinking/Audits/${tp.file.title}`);
}

const basename = `A${tp.date.now(format="DDMMyyyy-HHmmss")}`;
await tp.file.rename(basename);
const file = await tp.app.vault.getFileByPath(
	tp.file.path(true)
);

return `
# ${basename}
`.trim();
%>

