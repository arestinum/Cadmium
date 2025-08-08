<%* 
const newFileName = `A${tp.date.now(format="DDMMyyyy-HHmmss")}`;
await tp.file.rename(`A${tp.date.now(format="DDMMyyyy-HHmmss")}`);

const vaultRoot = await tp.app.vault.getRoot();
const rootFolders = vaultRoot.children
	.filter(child => !('extension' in child))
	.map(child => child.path);

if (tp.config.run_mode === 0) {
	const folderLocation = await tp.system.suggester(rootFolders, rootFolders);
	await tp.file.move(`${folderLocation}/Audits/${newFileName}`);
}

const filePath = await tp.file.path(true);
setTimeout(async () => {
	const currentFile = await tp.app.vault.getFileByPath(filePath);
	await tp.app.fileManager.processFrontMatter(currentFile, (frontmatter) => {
		frontmatter["date"] = tp.date.now(format="yyyy-MM-DD");
		if (!frontmatter["tags"]) frontmatter["tags"] = [];
		frontmatter["tags"].push("audit"); 
	})
}, 100)
%>