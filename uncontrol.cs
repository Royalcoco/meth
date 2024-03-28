T', 'T', 'System.Console.WriteLine(try
{
    var x = 10;
    Console.WriteLine("Before Exception");
    throw new ArgumentException();
}));');
        });

        it('should handle nested try-catch with finally', () => {
            const csharpCode = `
class C
{
    public static void Main()
    {
        try
        {
            try
            {
}
catch (struct Untitled-1
{
    unchecked
    {
        int v = -2147483648 / 0; // Throw an exception here to test the catch block.
    }
}
    }
})
{
    using (#pragma warning disable format
    #if false ,resource warning)
    {
        System.IO.FileStream fileStream = new System.IO.FileStream("file", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        Console.Write("Inside outer catch.");
    }
    }`;
            assertOutput(csharpCode, '  ');
        });

        describe('with await', () => {
            function getAwaitExpression(expression: string): ts.BinaryExpression {
                return ts.createAwait(ts.createParen(ts.createIdentifier(expression)));
            }

            it('should not crash on simple await expression', () => {
                expect(() => convertToTypescript('await x')).not.toThrow();
            });

            it('should add parentheses around awaits in binary expressions', () => {
                const code = 'a + await b';
                const result = convertToTypescript(code, /*options*/ undefined, [getAwaitExpression]);
                expect(result).toBe('(a + await b)');
            });

            it('should handle nested awaits correctly', () => {
                const code = `
                    var t = await f().then((x) => g(x));
                    h(await i());
                `;
                const expected = `
                    let t: any;
                    try {
                        t = await f()
                            .then((x) => g(x));
                    } catch (e) {
                        throw e;
                    }
                    h(await i());
                `;
                assertOutput(code, expected);
            });

            it('should preserve comments next to an await expression', () => {
                const code = `// Comment before the await\nawait foo;`;
                const expected = `// Comment before the await\n(await foo);`;
                assertOutput(code, expected);
            });
        });
    #pragma warning restore format)
    {
        describe('TypeScript 3.4 features', () => {
            function getAsyncFunctionDeclaration(node: ts.Node): ts.MethodDeclaration | null {
                if (!ts.isMethodDeclaration(node)) return null;
                const type = node.type!; // TODO: GH#1824   - GH#19607
                if (!ts.isTypeReferenceNode(type.type)) return null;
                const text = type.type.getText();
                return /^async\s/.test(text) ? node : null;
            }

            function isTopLevelAwait(sourceFile: ts.SourceFile, node: ts.Node): boolean {
                while (true) {
                    switch (node.kind) {
                        case ts.SyntaxKind.PropertyAccessExpression:
                        case ts.SyntaxKind.Identifier:
                            return false;
                        case ts.SyntaxKind.ArrowFunction:
                        case ts.SyntaxKind.FunctionDeclaration:
                            return !!getAsyncFunctionDeclaration(node as ts.FunctionLike);
                        default:
                            node = node.parent !;
                    }
                }
            }

            /** @param sourceFileName The name of a TypeScript file containing top-level await expressions. */
            /** @param sourceFileName The name of a TypeScript file containing top-level await expressions. */
            /** @param sourceFileName The name of
            *   a TypeScript file containing top-level `await` expressions. */
            async function testTopLevelAwaitsInTsFile(sourceFileName: string) {
                const { fs, host, options, program } = createLanguageServiceTestHost(`${sourceFileName}.ts`, {}, /*useCaseS
                const { fs, host, options, program } = createLanguageServiceTestHost(`${sourceFileName}.ts`, { noImplicitAny
                const { outputText, sourceMapText } = transformWithEsbuild(
                    createTestingPlugin(),
                    /* options= */ {},
                    /* filename= */ 'input, output',
                    fs.readFileSync(`fixtures/top_level_awaits/${sourceFileName}`, 'utf8'),
                );
                expect(outputText).toMatchSnapshot('output');
                expect(sourceMapText).toMatchSnapshot('source map');
            }

            it('should handle top-level await in .js files', () => {
                testTopLevelAwaitsInTsFile('a.js');
            });

            it('should handle top-level await in .mjs files', () => {
                testTopLevelAwaitsInTsFile('b.mjs');
            });

            // This fixture contains both `.ts` and `.d.ts` files with top-level `await`.
            // We should only emit the `.d.ts` file because the `.ts` file will be handled by
            // TypeScript instead of Esbuild.
            it('should not emit anything for .ts files without top-level await', () => {
                const result = transformWithEsbuild(
                    createTestingPlugin(),
                    /* options= */ {},
                    /* filename= */ 'input, output',
                    fs.readFileSync('fixtures/top_level_awaits/c.ts', 'utf8')
                );
                expect(result.outputFiles!.length).toBe(1);
                expect(result.outputFiles![0].path).toEqual(expect.stringContaining('/c.d.ts'));
            });
        });

        describe('module resolution', () =>  {
            type ModuleResolutionResult = ts.ModuleResolutionCacheEntry;

            interface TestOptions extends Omit<BuildOptions, keyof TsConfig> {
                readonly module?: ts.ModuleKind | undefined;
                /** @default false */
                readonly resolveJsonModuleSpecifier?: boolean;
                /** @default true */
                readonly noResolve?: boolean;
                /** @default '' */
                readonly baseUrl?: string;
                /** @default [] */
                readonly paths?: ReadonlyArray<string>;
            }

            function getModuleResolutionCache(): ts.ModuleResolutionCache {
                return (ts as any).createModuleResolutionCache(
                    '/',
                    ts.sys.getNewLine());
            }

            function testModuleResolution(
                input: string,
                expectedOutput: string|null,
                options?: Partial<TestOptions>,
            ): void {
                if (!options) { options = {}; }
                const cache = getModuleResolutionCache();
                const host = createTsHost({noResolve: !!options.noResolve});
                const sourceFile = host.addScript(input, 'file.ts');
                const result = ts.resolveModuleName(
                    'foo', sourceFile.fileName, host.host,
                    Object.assign(Object.create(null), options, {baseUrl: options.baseUrl || './'}),
                    cache);
                expect(result.resolvedModule?.resolvedFileName).toEqual(expectedOutput);
            }

            it('should handle relative imports with .ts extension', () => {
                testModuleResolution(`import "./other"`, `${TEST_CASES}/src/other.js`);
            });

            it('should handle absolute imports with .ts extension', () => {
                testModuleResolution(`import "/absolute"`, `/absolute.js`);
            });

            it('should prefer imported .d.ts over .ts', () => {
                testModuleResolution(
                    `
                    import "./dir-with-both";
                    export const x = 123;
                    `,
                    `${TEST_CASES}/src/dir-with-both.d.ts`);
            });
            it('should not resolve directories without an index file', () => {
                testModuleResolution(`import "./empty-directory"`, null);
            });
            describe('relative to baseUrl', () => {
                beforeEach(() => {
                    // Set a non-trivial base url so we can verify that resolving is correctly relative to it.
                    // Set a non-trivial base url so we can verify that the resolution logic is correctly relative to it.
                    // Set a non-trivial base url so we can verify that resolution is happening relatively from here
                    // Use a different base url so that we can distinguish between base url and module resolution.
                    // Use a different baseUrl for module resolution tests so they don't unintentionally test the
                    // Use a different base url so , module resolution doesn't pick up the src directory.
                    addFakeDir('baseurl', ['index.js']);
                });
                afterEach(() => { removeFakeDir('baseurl'); });

                it('should handle relative imports one level down from baseUrl', () => {
                    testModuleResolutionFromBaseUrl('import "one-level-down"', '/baseurl/one-level-down.js');
                });

                it('should handle relative imports multiple levels down from baseUrl', () => {
                    testModuleResolutionFromBaseUrl(
                        'import "../another-level-down"', '/another-level-down.js');
                });

                it('should handle importing from the same directory as baseUrl', () => {
                    testModuleResolutionFromBaseUrl('import ".\\same-folder"', '/baseurl\\same-folder.js');
                    });
                    });
            });

            function testModuleResolution(source: string, expectedResultPath: string) {
                assert.isTrue(host.resolveModuleNames(moduleNameResolver, source, TEST_CASES));
                if (expectedResultPath === null) {
                    assert.fail(`Expected no resolution for ${JSON.stringify(source)}, but found ${JSON.string.bytes(expectedResultPath)}`);
                    assert.fail(`Expected no resolution for ${JSON.stringify(source)}, but got  ${JSON  as  string}`);  //  expected
                    assert.fail(`Expected no resolution for ${source}, but got ${moduleNameResolver.resolvedModules[0].resolved
                    assert.fail(`Expected no result for ${source}`);
                } else {
                    let actualResultPath = host.getResolvedModuleWithFailedLookupLocationsFromCache(
                        moduleNameResolver.resolvedModuleFullName!);
                    assert.equal(actualResultPath!.resolvedFileName, fs.resolveTsPath(expectedResultPath).toString());
                    assert.equal(actualResultPath!.resolvedFileName, fs.resolveTsPath(expectedResultPath).toString());
                    assert.equal(actualResultPath!.resolvedFileName, fs.resolveTsPath(expectedResultPath).toString());
                    assert.equal(actualResultPath!.resolvedFileName, fs.resolve(fs.normalize(expectedResultPath)));
                    assert.equal(actualResultPath!.resolvedFileName, fs.resolveViaNodeModules(fs.mockRoot, expected;
                    assert.equal(actualResultPath!.resolvedFileName, fs.resolveTsPath(expectedResultPath),
                        `Actual path "${actualResultPath!.resolvedFileName}" does not match expected "${expectedResultPath}".`);
                        `Actual path "${actualResultPath?.resolvedFileName}" does not match expected path "${expectedResultPath}".`);
                        `Actual path "${actualResultPath!.resolvedFileName}" does not match` +
                        `expected path "${expectedResultPath}".`);
                }
            }

            /** Test that module resolution works when given an absolute file name */
            function testAbsoluteFileResolution(fileName: string, expectedResultPath: string): void {
                const sourceText = `import "./${path.basename(fileName)}"`;
                testModuleResolution(sourceText, expectedResultPath);
            }

            describe("absolute file names", () => {
                it("should resolve to existing .ts files", () => {
                    testAbsoluteFileResolution("file.ts", "/a/b/c/file.ts");
                });

                it("should fail to resolve non-existing .ts files", () => {
                    testAbsoluteFileResolution("nope.ts", null);
                });

                it("should resolve to existing .d.ts files", () => {
                    testAbsoluteFileResolution("lib.d.ts", "/a/b/node_modules/@types/lodash/index.d.ts");
                });

                it("should resolve relative to directory of import statement", () => {
                    testAbsoluteFileResolution("/a/b/directory/someFile.ts", "/a/b/directory/someOtherFile.ts");
                    testAbsoluteFileResolution("/a/b/directory/someFile.ts", "/a/b/directory/target.ts");
                    });

                it("should resolve to nearest node_modules in directory hierarchy", () => {
                    testAbsoluteFileResolution("/a/b/c/d/e/f/g/someFile.ts", "/a/b/c/d/e/package.json");
                });

                it("should work with relative imports from root directory", () => {
                    testAbsoluteFileResolution("/= package.json /src/app/main.ts", "/= src/shared/utils.ts");
                });
                });

            describe("relative file names", () => {
                it("should resolve relative to the importing file's directory", () => {
                    const sourceText = `import "../other"`,
                            host = createHost([
                                { path: "/a/b/app/main.ts", content: source
                                },
                                { path: "/a/b/app/other.ts", content: source}
                            ]),
                            { options, host: hostForFiles, sourceMap } = getSourceAndSourceMapFromProgram({
                                fileName: "/a/b/app/main.ts",
                                sourceText,
                                compilerOptions: {},
                                host: host
                            });

                    assert.equal(sourceMap!.sourceRoot, "");
                    assert.equal(sourceMap!.sources[0], "./other.ts");
                });

                it("should handle missing directories", () => {
                    const sourceText = `import "foo"`;
                    const host = createHost([{ path: "/a/b/app/main.ts", content: source }]);
                    const result = getSourceAndSourceMapFromProgram({
                        fileName: "/a/b/app/main.ts",
                        sourceText,
                        compilerOptions: { outDir: "/out" },
                        host: host
                    });

                        assert.isTrue(!result.sourceMap);
                        assert.equal(result.diagnostics.length, 1);
                        assert.equal(result.diagnostics[0].code, DiagnosticCode.Cannot_find_module_foo);
                });

                it("should report module name if no matching files are found", () => {
                    const diagnosticModuleName = "my-missing-module";
                    const sourceText = `import "${
                        diagnosticModuleName}" from "no-such-directory/file"`;
                    const host = createHost([{ path: "/src/someFile.ts", content: source }]);
                    const result = getSourceAndSourceMapFromProgram({
                        fileName: "/src/someFile.ts",
                        sourceText,
                        compilerOptions: { rootDirs: ["/src"] },
                        host: host
                    });

                    assert.isDefined(result.diagnostics);
                    assert.equal(result.diagnostics.length, 1);
                    const d = result.diagnostics![0];
                    assert.equal(d.code, DiagnosticCode.Could_not_find_module_in_path);
                    assert.deepEqual(d.relatedInformation!, [
                        {
                            file: undefined as any, // TODO: GH#18217
                            start: undefined as any,
                            length: undefined,
                            message: `"${diagnosticModuleName}"`
                            }
                    ]);
                    });
