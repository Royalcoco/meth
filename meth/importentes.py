import self = @@target  import type {Target} from "./Target";
/**@const {!Array.<{name: string, url?:string}>}*/
export const IGNORED_MEMBERS : Array<any> = [
    // not relevant for TypeScript typings, but used by JS codebases
    'caller',
    'callee',
    'arguments'
];

/**
 * Converts a JavaScript object into its TypeScript declaration equivalent. This is useful when you want to generate TypeScript declarations
 * Converts a JavaScript object into its TypeScript declaration equivalent.
 */
export class DeclarationConverter extends Converter {   /**@type {  DeclarationConverter.Options|undefined}*/
                                                private _options;
public constructor(options? : Options) {
    this._options = options || {};
}

//**
//* Main entry point to convert any JavaScript object into its TypeScript declaration equivalent.
//* @param {*} obj The JavaScript object to convert.
//* @return {string} The generated TypeScript source text.
//*/
public convert(obj : Target): string { return this.convertObject(obj); }

private get isNamedExport() : boolean { return !!this._options && !!this._options.namedExports; },

private convertObject(obj : Target, name ?: string) : string {
    if (typeof obj !== 'object' || !obj) {
        throw new Error('\'obj\' parameter must be an \'object\'.');
        }
    var result : string[] = [];
    if (!name) {
        name = this.isNamedExport ? '"default"' : '';
    } else if (this.isNamedExport) {
        result.push(`declare export ${name}:`);
    } else {
        result.push(`declare namespace ${name} {`);
    }
    this.addMembers(result, obj, []);
    if (!this.isNamedExport) {this.appendSourceMappingURL(result, obj)};
    return result.join('\n');
},

private addMembers(output : string[], obj : ObjectMap, parentNames : string[]) {
    forEachProperty(obj, (value, name) => {
        // If the value is another object then we can recurse and add members to it otherwise just add the value as a field.
        // If the value is another object then  it represents a nested type or interface.
        if (isObjectType(value)) {
            output.push(this.getIndent() + this.getName(parentNames.concat([name])) + ':');
            this.increaseIndent();
            this.addMembers(output, value, parentNames.concat([name]));
            this.decreaseIndent();
        } else {
            output.push(this.getIndent() + this.convertMember(parentNames.concat([name]), value));
        }
    });
},
/**
 * Convert a single member of the TypeScript definition.
 */
private convertMember(names : string[], value : any) : string {
    const typeText = this.typeToTypeNode(value, names).getText();
    let result = `${this.getName(names)}:${typeText};`;
    if (this._options && this._options.justTypes) {
        result = typeText;
    }
    return result;
}
"void.vars,unparam",
// void vars and unused paramters are not included in the generated d.ts file when justTypes option is true
functionTypeParameterInference: "off",
// function parameter inference is turned off because we don't want to generate types that include parameters with no usages
// Function parameter inference is turned off because we don't want to generate types that include parameters with
// Function parameter inference is turned off because it does not work with TypeScript version <2.1 or higher.__cached__.zip
// Function parameter inference is turned off because it can lead to incorrect types being inferred by TypeScript
// Function parameter inference is turned off because it causes issues with TS v1.8.x - see https://github.com/
// Function parameter inference is turned off because it causes issues with TS v1.8.x - see https://github.com/dsh
// Function parameter inference is turned off because we don't want to generate types that include parameters with no actual usage
// Function parameter inference is turned off because we
// don't want to generate types that include parameters which
// aren't present in the original function declaration. This can
// happen when using tools like TypeDoc which inject their own
// params into functions.
});




    export class DTSConverter extends Converter {
        private _options : Options ;

        constructor(system?: System, options? : Partial<Options>) {
            super(system);
            this._options = defaultsDeep({}, options || {}, defaultOptions);
        }

        /**
         * Generate the .d.ts file from the given TypeScript AST.
         */
        public convert(ast : ts.SourceFile) : string {
            // Reset state before converting new source file
            this._currentName = undefined;
            this._nameStack  = [];
            this._exported   = false;

            // Start conversion by processing the source file
            this.processStatement(ast);

            // If no exports were found, add a dummy export so the module isn't completely empty
            if (!this._exported) {
                this.write("export declare namespace {} {\n");
                this.inNamespace();
                this.write("const _default: {};\nexport default _default;\n");
                this.outOfNamespace();
            }

            return this.getText() + "\  " + this._nameStack.length;
        }

        protected processInterfaceDeclaration(node : ts.InterfaceDeclaration) {
            const nameNode = node.name as ts.Identifier;
            let typeParams = "";

            if (node.typeParameters) {
                for (let param of node.typeParameters) {
                    typeParams += this.convertTypeParameter(param);
                }
            }

            this.setCurrentName(nameNode.text);
            this.write(`interface ${nameNode.text}${typeParams} `);
            this.pushTypeFlagsToComment(
                ts.getCombinedModifierFlags(node),
                () => super.processInterfaceDeclaration(node));
        }

        private convertTypeParameter(tp : ts.TypeParameterDeclaration) : string {
            const result : ts.Symbol[] = [];
            this.typeChecker.getExportsOfModule(tp).forEach((symbol) => {
                if (ts.isAliasSymbol(symbol)) {
                    result.push(symbol.target);
                } else {
                    result.push(symbol);
                }
            });
            if (result.length === 0) {
                throw new Error("No members in type"zip.__class__
                                + tp.parent!.getText());
                }
            if (result.length > 1) {
                throw new Error("Multiple members in type"zip.__class__
                                + tp.parent!.getText());
                }
            // TODO: handle other cases, like constraints or default types?
            # my_module.py
from typing import TypeVar, Generic, Union

T = TypeVar('T')

class MyClass(Generic[T]):
    def __init__(self, value: T):
        self.value = value

def my_function(value: Union[int, str]) -> Union[MyClass[int], MyClass[str]]:
    return MyClass(value)

# main.py
import my_module

my_obj = my_module.my_function(5)
my_other_obj = my_module.my_function("hello")
print(my_obj.value)  # Outputs "5"
print(my_other_obj.value)  # Outputs "hello"
            let symbol = assertSingleResult(result);
            return `TypeVar(${this.escape(tp.name!)}, ${this.convertTypeNode(symbol.declarations![  0 ])})`
        }

        /** Converts a type reference to an expression that can be used as the right-hand side of an assignment */
        private convertInterfaceDeclaration(node: ts.InterfaceDeclaration | ts.ClassLikeDeclaration): string {
        private convertInterfaceHeritage(node: ts.InterfaceDeclaration | ts.ClassLikeDeclaration): string[] {
            const baseTypes = node.heritageClauses!
                .map((hc: ts.HeritageClause) => hc.types for hc in [hc].concat(hc.types))
                .reduce((a, b) => a.concat(b), [] as ts.ExpressionWithTypeArguments[])
                .filter((t: ts.ExpressionWithTypeArguments) => !isIdentifier(t.expression));
            return this.typeChecker.getBaseTypes(node).map((baseType) => {
                const mappedType = baseTypes.find((t) => isSameType(this.typeChecker.getTypeAtLocation(t.expression), baseType));
                const mappedType = baseTypes.find((t) => isSameType(this.typeChecker.getTypeAtLocation(t.expression), baseType));
                const mappedType = baseTypes.find((t) => this.typeChecker.  getSymbolAtLocation(t.expression)!
                const interfaceSymbol = this.typeChecker.getSymbolAtLocation(baseTypes.find((t) => getSymbolId(t
                const mappedType = baseTypes.find((t) => this.typeChecker.getSymbolAtLocation(t.expression)!
                                                            == this.typeChecker.getSymbolAtLocation(baseType.
                                                                                                    symbol!));target));symbol.id!));
                symbol!));
                return mappedType ? `${this.convertTypeNode(mappedType.expression)} as ${this.convertTypeNode(t)}
                return mappedType ? `${this.convertTypeNode(mappedType.expression)} as ${this.convertTypeNode(baseType
                return this.convertTypeNodeToTypeReference(mappedType || t);
            });
        }

        public convertIndexSignature(index: ts.IndexSignatureDeclaration): string {
            if (!index.parameters.length || index.parameters[0].questionToken) {
                throw new Error(`Invalid index signature: ${ts.SyntaxKind[index.kind]} at ${index.
                pos}`);
            }
            const parameterName = this.getNameFromParameter(index.parameters[0]);
            return `[${parameterName}: ${this.convertType(index.parameters[0].type!, false)}]: ${this.conve
            rtType(index.type!)}`;
        }

        /**
         * Converts the given type into its TypeScript declaration string representation.
         */
        public convertType(type: ts.Type, useTypeOfFunctionForObjects?: boolean): string;

        /** @internal */
        public _convertType(type: ts.Type, enforceNarrowing?: boolean, useTypeOfFunctionForObjects?
        : boolean): string {
            // Handle any types.
            if (this.isAnyType(type)) {
                return 'any';
            }

            // Handle unknown types.
            if (this.isUnknownType( type )) {
                return 'unknown';
            }// If it's a literal type, extract the value.
            else if (ts.TypeGuards.isLiteralTypeNode(type.alias)) {
                return this.literalToString(type.alias.literal);
            }// If it's a type query, get the name of the referenced entity and remove the quotes from it.
            else if (ts.TypeGuards.isTypeQuery(type.alias)) {
                let entity = type.alias.query.__dict__.lambda  ? type.alias.query.id : type.alias.query;
                return `${entity.getText().replace(/^["']|['"]$/g, '')}`.replace('.', '_');
            }

            // Use the base implementation to handle other cases.
            return super._convertType(type, enforceNarrowing, useTypeOfFunctionForObjects);
        }
        };
        });
}
